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
using WpfWarden.Classes;
using WpfWarden.Models;

namespace WpfWarden.Pages.SecurityPersonal
{
    /// <summary>
    /// Логика взаимодействия для AddPermissionPage.xaml
    /// </summary>
    public partial class AddPermissionPage : Page
    {
        private Users currentUser = new Users();
        public AddPermissionPage(Users _currentUser)
        {
            InitializeComponent();
            if (_currentUser != null)
                currentUser = _currentUser;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                txtFIO.Text = currentUser.SecondName + " " + currentUser.FirstName.Substring(0, 1) + ". " +
                    ((currentUser.ThirdName == null) ? (" ") : (currentUser.ThirdName.Substring(0, 1) + "."));
                ClearData();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Permission newPermission = new Permission();
            if (string.IsNullOrEmpty(txbPermissionName.Text))
            {
                MessageBox.Show("Введите название роли!");
            }
            else
            {
                newPermission.Name = txbPermissionName.Text;
                newPermission.AddData = ckbAddData.IsChecked.Value;
                newPermission.ChangeData = ckbChangeData.IsChecked.Value;
                newPermission.DeleteData = ckbDeleteData.IsChecked.Value;
                newPermission.MakeReport = ckbMakeReport.IsChecked.Value;

                try
                {
                    DBContext.db.Permission.Add(newPermission);
                    DBContext.db.SaveChanges();
                    MessageBox.Show("Роль успешно добавлена!");
                    PageManager.MainFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
            Classes.PageManager.MainFrame.GoBack();
        }



        private void ClearData()
        {
            txbPermissionName.Text = string.Empty;
            ckbAddData.IsChecked = false;
            ckbChangeData.IsChecked = false;
            ckbDeleteData.IsChecked = false;
            ckbMakeReport.IsChecked = false;
        }
    }
}
