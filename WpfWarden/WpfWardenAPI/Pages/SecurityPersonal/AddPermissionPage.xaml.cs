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
    /// Логика взаимодействия для AddPermissionPage.xaml
    /// </summary>
    public partial class AddPermissionPage : Page
    {
        private User currentUser = new User();
        public AddPermissionPage(User _currentUser)
        {
            InitializeComponent();
            if (_currentUser != null)
                currentUser = _currentUser;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                txtFIO.Text = currentUser.secondName + " " + currentUser.firstName.Substring(0, 1) + ". " +
                    ((currentUser.thirdName == null) ? (" ") : (currentUser.thirdName.Substring(0, 1) + "."));
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
                newPermission.name = txbPermissionName.Text;
                newPermission.addData = ckbAddData.IsChecked.Value;
                newPermission.changeData = ckbChangeData.IsChecked.Value;
                newPermission.deleteData = ckbDeleteData.IsChecked.Value;
                newPermission.makeReport = ckbMakeReport.IsChecked.Value;

                if (string.IsNullOrEmpty(APIContext.Post("Permissions", JsonConvert.SerializeObject(newPermission))))
                {
                    MessageBox.Show("Роль успешно добавлена!");
                    PageManager.MainFrame.GoBack();

                    Logger.Trace("Сотрудник ИБ добавил роль", currentUser);
                    Logger.Trace("Сотрудник ИБ переходит на главную страницу", currentUser);
                }
                else
                {
                    MessageBox.Show("Не удалось добавить роль");
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
            Classes.PageManager.MainFrame.GoBack();

            Logger.Trace("Сотрудник ИБ переходит на главную страницу (отмена действия)", currentUser);
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
