using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Entity;
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
using WpfWarden.Classes;
using WpfWarden.Models;
using WpfWarden.Classes.Logger;

namespace WpfWarden.Pages.SecurityPersonal
{
    /// <summary>
    /// Логика взаимодействия для InfoSecurerPage.xaml
    /// </summary>
    public partial class InfoSecurerPage : Page
    {
        private Users currentUser = new Users();
        List<Permission> permissions = new List<Permission>();
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
                            || string.IsNullOrEmpty(usersToVerify[i].SecretWord) || usersToVerify[i].Permission.Name == null)
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
                else if (verifiedUsersCount> 0)
                {
                    DBContext.db.SaveChanges();
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
            }
        }



        private void RefreshData()
        {
            usersToVerify = DBContext.db.Users.Where(x => x.IsVerify == false && x.IsBlocked == false).ToList();
            DGUsersForVerify.ItemsSource = DBContext.db.Users.Where(x => x.IsVerify == false).ToList();

            permissions = DBContext.db.Permission.ToList();
            CmbRole.ItemsSource = permissions;
            DGPermissions.ItemsSource = permissions;

            LVBlockedUsers.ItemsSource = DBContext.db.Users.Where(x => x.IsBlocked == true).ToList();

            txtFIO.Text = currentUser.SecondName + " " + currentUser.FirstName.Substring(0, 1) + ". " + 
                ((currentUser.ThirdName == null) ? (" ") : (currentUser.ThirdName.Substring(0, 1) + "."));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
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
                    for (int i = 0; i < permissionsToDelete.Count(); i++)
                    {
                        List<Users> tempUsers = DBContext.db.Users.ToList();
                        List<Users> users = tempUsers.Where(x => x.PermissionId == permissionsToDelete[i].PermissionId).ToList();
                        for (int j = 0; j < users.Count(); j++)
                        {
                            users[j].PermissionId = null;
                            users[j].IsVerify = false;
                        }
                        DBContext.db.Permission.Remove(permissionsToDelete[i]);
                    }
                    DBContext.db.SaveChanges();
                    RefreshData();
                    MessageBox.Show("Данные успешно удалены!");

                    Logger.Warn($"Сотрудник ИБ удалил уровни доступа в количестве {permissionsToDelete.Count()} штук", currentUser);
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
            try
            {
                DBContext.db.SaveChanges();
                RefreshData();
                MessageBox.Show("Данные успешно сохранены!");

                Logger.Trace("Сотрудник ИБ сохранил изменения уровней доступа", currentUser);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, currentUser);
                MessageBox.Show(ex.Message);
            }
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
                Logger.Trace($"Сотрудник ИБ перешёл на страницу переписки с пользователем {checkedUser.UserId} из чёрного списка", currentUser);
            }
            catch { }
            PageManager.MainFrame.Navigate(new BlockedUserInfo(currentUser, checkedUser));

        }
    }
}
