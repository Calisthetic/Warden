using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
    /// Логика взаимодействия для AdministratorPage.xaml
    /// </summary>
    public partial class AdministratorPage : Page
    {
        private User currentUser = new User();
        public AdministratorPage(User _currentUser)
        {
            InitializeComponent();
            if (_currentUser != null)
                currentUser = _currentUser;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                string resultString = APIContext.Get("Divisions");
                if (string.IsNullOrEmpty(resultString))
                {
                    MessageBox.Show("Не получилось найти данные должностей сотрудников...");
                } else {
                    List<Division> divisions = JsonConvert.DeserializeObject<List<Division>>(resultString);
                    divisions.Insert(0, new Division
                    {
                        name = "Не выбрано"
                    });
                    cmbDivision.ItemsSource = divisions;
                    cmbDivision.SelectedIndex = 0;
                }
               
                txtFIO.Text = currentUser.secondName + " " + currentUser.firstName.Substring(0, 1) + ". " +
                    ((currentUser.thirdName == null) ? (" ") : (currentUser.thirdName.Substring(0, 1) + "."));
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(txbFirstName.Text))
                errors.AppendLine("Имя не указано");
            if (string.IsNullOrEmpty(txbSecondName.Text))
                errors.AppendLine("Фамилия не указана");
            if (cmbGender.SelectedIndex == 0)
                errors.AppendLine("Выберите пол");
            if (cmbDivision.SelectedIndex == 0)
                errors.AppendLine("Выберите должность");

            if (errors.Length == 0)
            {
                Division selectedDivision = cmbDivision.SelectedItem as Division;

                User newUser = new();
                newUser.firstName = txbFirstName.Text;
                newUser.secondName = txbSecondName.Text;
                newUser.thirdName = string.IsNullOrEmpty(txbThirdName.Text) ? null : txbThirdName.Text;
                newUser.divisionId = selectedDivision.divisionId;
                newUser.gender = (cmbGender.SelectedIndex == 1) ? (true) : (false);

                var response = APIContext.Post("Users", JsonConvert.SerializeObject(newUser));

                if (!string.IsNullOrEmpty(response))
                {
                    //var result = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Пользователь успешно добавлен!");
                    Logger.Trace($"Администратор добавил нового пользователя id:{newUser.userId}", currentUser);
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Не удалось добавить пользователя");
                }

                //catch (DbEntityValidationException er)
                //{
                //    foreach (var eve in er.EntityValidationErrors)
                //    {
                //        MessageBox.Show("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:" +
                //            eve.Entry.Entity.GetType().Name + eve.Entry.State);
                //        foreach (var ve in eve.ValidationErrors)
                //        {
                //            MessageBox.Show("- Property: \"{0}\", Error: \"{1}\"" +
                //                ve.PropertyName + ve.ErrorMessage);
                //        }
                //    }
                //}
            }
            else
                MessageBox.Show(errors.ToString());
        }



        private void ClearFields()
        {
            txbFirstName.Text = string.Empty;
            txbSecondName.Text = string.Empty;
            txbThirdName.Text = string.Empty;
            cmbDivision.SelectedIndex = 0;
            cmbGender.SelectedIndex = 0;
        }
    }
}
