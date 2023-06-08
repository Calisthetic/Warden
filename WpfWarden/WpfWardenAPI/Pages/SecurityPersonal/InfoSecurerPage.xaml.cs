using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfWardenAPI.Classes;
using WpfWardenAPI.Classes.Logger;
using WpfWardenAPI.Models;

namespace WpfWardenAPI.Pages.SecurityPersonal
{
    /// <summary>
    /// Логика взаимодействия для InfoSecurerPage.xaml
    /// </summary>
    public partial class InfoSecurerPage : Page
    {
        private User currentUser = new User();
        List<Permission> permissions = new List<Permission>();
        List<User> usersToVerify = new List<User>();
        public InfoSecurerPage(User _currentUser)
        {
            InitializeComponent();
            if (_currentUser != null)
                currentUser = _currentUser;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int verifiedUsersCount = 0;
                bool error = false;
                for (int i = 0; i < usersToVerify.Count; i++)
                {
                    if (usersToVerify[i].isVerify == true)
                    {
                        verifiedUsersCount++;
                        if (string.IsNullOrEmpty(usersToVerify[i].login) || string.IsNullOrEmpty(usersToVerify[i].password)
                            || string.IsNullOrEmpty(usersToVerify[i].secretWord) || usersToVerify[i].permission.name == null)
                        {
                            error = true;
                            break;
                        }
                    }
                }
                if (error)
                {
                    MessageBox.Show("Кажется, Вы заполнили не все поля");
                }
                else if (verifiedUsersCount > 0)
                {
                    //DBContext.db.SaveChanges();////////////////////////////////////////////////
                    MessageBox.Show("Изменения успешно сохранены!");
                    RefreshData();

                    Logger.Trace($"Сотрудник ИБ проверил {verifiedUsersCount} пользователей");
                }
                else
                {
                    MessageBox.Show("Выберите пользователей на одобрение");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, currentUser);
                MessageBox.Show(ex.Message);
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                RefreshData();
                ((MainWindow)Application.Current.MainWindow).txtTitle.Text = "Warden";
                ((MainWindow)Application.Current.MainWindow).txtTitle.FontSize = 30;
            }
        }



        private void RefreshData()
        {
            string result = APIContext.Get("Users?IsVerify=false");
            if (!string.IsNullOrEmpty(result))
            {
                usersToVerify = JsonConvert.DeserializeObject<List<User>>(result);
                DGUsersForVerify.ItemsSource = usersToVerify;
            }

            result = APIContext.Get("Permissions");
            if (!string.IsNullOrEmpty(result))
            {
                CmbRole.ItemsSource = permissions;
                DGPermissions.ItemsSource = permissions;
            }

            string usersMessagesResult = APIContext.Get("Users/Messages");
            if (string.IsNullOrEmpty(usersMessagesResult))
            {
                //MessageBox.Show("Не удалось получить сообщения пользователей");
            }
            else
            {
                List<UserMessagesCount> blockedUsers = JsonConvert.DeserializeObject<List<UserMessagesCount>>(usersMessagesResult);// DBContext.db.Users.Where(x => x.IsBlocked == true).ToList();//OrderBy(x => x.UncheckedMessagesCount).ToList();
                for (int i = 0; i < blockedUsers.Count - 1; i++)
                {
                    for (int j = 0; j < blockedUsers.Count - i - 1; j++)
                    {
                        //if (blockedUsers[j].lastMessageTime < blockedUsers[j + 1].lastMessageTime)
                        //{
                        //    UserMessagesCount temp = blockedUsers[j];
                        //    blockedUsers[j] = blockedUsers[j + 1];
                        //    blockedUsers[j + 1] = temp;
                        //}
                    }
                }
                LVBlockedUsers.ItemsSource = blockedUsers;
            }

            txtFIO.Text = currentUser.secondName + " " + currentUser.firstName.Substring(0, 1) + ". " +
                ((currentUser.thirdName == null) ? (" ") : (currentUser.thirdName.Substring(0, 1) + "."));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string permissionsResponse = APIContext.Get("Permissions");
            List<Permission> permissionsToDelete = DGPermissions.SelectedItems.Cast<Permission>().ToList();
            if (permissionsToDelete.Count() == 0)
            {
                MessageBox.Show("Выберите уровень доступа");
            }
            else if (MessageBox.Show($"Вы действительно хотите удалить эти роли в количестве {permissionsToDelete.Count()} штук?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    bool error = false;
                    for (int i = 0; i < permissionsToDelete.Count(); i++)
                    {
                        string usersResponse = APIContext.Get("Users");
                        if (!string.IsNullOrEmpty(usersResponse))
                        {
                            List<User> tempUsers = JsonConvert.DeserializeObject<List<User>>(usersResponse);
                            List<User> users = tempUsers.Where(x => x.permissionId == permissionsToDelete[i].permissionId).ToList();
                            for (int j = 0; j < users.Count(); j++)
                            {
                                users[j].permissionId = null;
                                users[j].isVerify = false;
                            }
                            string deleteResult = APIContext.Delete("Permissions/" + permissionsToDelete[i].permissionId);
                            if (string.IsNullOrEmpty(deleteResult))
                            {
                                error = true;
                            }
                        }
                    }
                    RefreshData();
                    if (error)
                    {
                        MessageBox.Show("Что-то пошло не так");
                    }
                    else
                    {
                        MessageBox.Show("Данные успешно удалены!");
                        Logger.Warn($"Сотрудник ИБ удалил уровни доступа в количестве {permissionsToDelete.Count()} штук", currentUser);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, currentUser);
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    DBContext.db.SaveChanges();
            //    RefreshData();
            //    MessageBox.Show("Данные успешно сохранены!");

            //    Logger.Trace("Сотрудник ИБ сохранил изменения уровней доступа", currentUser);
            //}
            //catch (Exception ex)
            //{
            //    Logger.Error(ex, currentUser);
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            PageManager.MainFrame.Navigate(new AddPermissionPage(currentUser));

            Logger.Trace("Сотрудник ИБ перешёл на страницу добавления уровня доступа", currentUser);
        }

        private void LVBlockedUsers_Selected(object sender, RoutedEventArgs e)
        {
            UserMessagesCount checkedUser1 = LVBlockedUsers.SelectedItem as UserMessagesCount;
            User checkedUser = checkedUser1 == null ? null : checkedUser1.sendlerUser as User;
            if (checkedUser != null)
            {
                Logger.Trace($"Сотрудник ИБ перешёл на страницу переписки с пользователем {checkedUser.userId} из чёрного списка", currentUser);
                PageManager.MainFrame.Navigate(new BlockedUserInfo(currentUser, checkedUser));
            }
        }
    }
}
