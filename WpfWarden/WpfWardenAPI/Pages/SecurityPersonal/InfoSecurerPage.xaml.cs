using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        private Users currentUser = new Users();
        List<Permissions> permissions = new List<Permissions>();
        List<Users> usersToVerify = new List<Users>();
        public InfoSecurerPage(Users _currentUser)
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
                    if (usersToVerify[i].IsVerify == true)
                    {
                        verifiedUsersCount++;
                        if (string.IsNullOrEmpty(usersToVerify[i].Login) || string.IsNullOrEmpty(usersToVerify[i].Password)
                            || string.IsNullOrEmpty(usersToVerify[i].SecretWord) || usersToVerify[i].PermissionName == null)
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
            //usersToVerify = DBContext.db.Users.Where(x => x.IsVerify == false && x.IsBlocked == false).ToList();
            //DGUsersForVerify.ItemsSource = DBContext.db.Users.Where(x => x.IsVerify == false).ToList();

            //permissions = DBContext.db.Permission.ToList();
            //CmbRole.ItemsSource = permissions;
            //DGPermissions.ItemsSource = permissions;

            string usersMessagesResult = APIContext.Get("UsersMessages");
            if (string.IsNullOrEmpty(usersMessagesResult))
            {
                MessageBox.Show("Не удалось получить сообщения пользователей");
            }
            else
            {
                List<ResponseUsersMessage> blockedUsers = JsonConvert.DeserializeObject<List<ResponseUsersMessage>>(APIContext.Get("UsersMessages"));// DBContext.db.Users.Where(x => x.IsBlocked == true).ToList();//OrderBy(x => x.UncheckedMessagesCount).ToList();
                for (int i = 0; i < blockedUsers.Count - 1; i++)
                {
                    for (int j = 0; j < blockedUsers.Count - i - 1; j++)
                    {
                        if (blockedUsers[j].LastMessageTime < blockedUsers[j + 1].LastMessageTime)
                        {
                            ResponseUsersMessage temp = blockedUsers[j];
                            blockedUsers[j] = blockedUsers[j + 1];
                            blockedUsers[j + 1] = temp;
                        }
                    }
                }
                LVBlockedUsers.ItemsSource = blockedUsers;
            }
            //    Classes.DBContext.db.BlockedUserMessages.Where(x1 => x1.Time > (
            //        Classes.DBContext.db.Logs.Where(x2 => x.Permission.Name == "Специалист по ИБ").OrderByDescending(x3 => x3.Logged).Skip(1).FirstOrDefault().Logged
            //    ) && x1.SendlerUserId == x.UserId).Count()
            //).ToList();

            txtFIO.Text = currentUser.SecondName + " " + currentUser.FirstName.Substring(0, 1) + ". " +
                ((currentUser.ThirdName == null) ? (" ") : (currentUser.ThirdName.Substring(0, 1) + "."));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string permissionsResponse = APIContext.Get("Permissions");
            List<Permissions> permissionsToDelete = DGPermissions.SelectedItems.Cast<Permissions>().ToList();
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
                            List<Users> tempUsers = JsonConvert.DeserializeObject<List<Users>>(usersResponse);
                            List<Users> users = tempUsers.Where(x => x.PermissionId == permissionsToDelete[i].PermissionId).ToList();
                            for (int j = 0; j < users.Count(); j++)
                            {
                                users[j].PermissionId = null;
                                users[j].IsVerify = false;
                            }
                            string deleteResult = APIContext.Delete("Permissions/" + permissionsToDelete[i].PermissionId);
                            if (string.IsNullOrEmpty(deleteResult))
                            {
                                error = true;
                            }
                        }
                    }
                    //DBContext.db.SaveChanges();
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
            Users checkedUser = LVBlockedUsers.SelectedItem as Users;
            try
            {
                if (checkedUser != null)
                {
                    Logger.Trace($"Сотрудник ИБ перешёл на страницу переписки с пользователем {checkedUser.UserId} из чёрного списка", currentUser);
                    //PageManager.MainFrame.Navigate(new BlockedUserInfo(currentUser, checkedUser));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }
}
