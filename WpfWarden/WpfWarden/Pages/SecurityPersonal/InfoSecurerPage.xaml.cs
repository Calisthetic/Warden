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
                bool error = false;
                for (int i = 0; i < usersToVerify.Count; i++)
                {
                    if (usersToVerify[i].IsVerify == true)
                    {
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
                else
                {
                    DBContext.db.SaveChanges();
                    MessageBox.Show("Изменения успешно сохранены!");
                    RefreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            RefreshData();
        }



        private void RefreshData()
        {
            usersToVerify = DBContext.db.Users.Where(x => x.IsVerify == false).ToList();
            DGUsersForVerify.ItemsSource = DBContext.db.Users.OrderBy(x => x.IsVerify).ToList();

            permissions = DBContext.db.Permission.ToList();
            CmbRole.ItemsSource = permissions;
            DGPermissions.ItemsSource = permissions;

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
                }
                catch (DbEntityValidationException ex)
                {
                    MessageBox.Show(ex.Message.ToString());
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
