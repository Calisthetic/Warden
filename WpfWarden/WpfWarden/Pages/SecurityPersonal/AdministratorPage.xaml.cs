using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
using WpfWarden.Classes.Logger;
using WpfWarden.Models;

namespace WpfWarden.Pages.SecurityPersonal
{
    /// <summary>
    /// Логика взаимодействия для AdministratorPage.xaml
    /// </summary>
    public partial class AdministratorPage : Page
    {
        private Users currentUser = new Users();
        public AdministratorPage(Users _currentUser)
        {
            InitializeComponent();
            if (_currentUser != null)
                currentUser = _currentUser;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                var divisions = DBContext.db.Division.ToList();
                divisions.Insert(0, new Division
                {
                    Name = "Не выбрано"
                });
                cmbDivision.ItemsSource = divisions;
                cmbDivision.SelectedIndex = 0;
                txtFIO.Text = currentUser.SecondName + " " + currentUser.FirstName.Substring(0, 1) + ". " + 
                    ((currentUser.ThirdName == null)?(" "):(currentUser.ThirdName.Substring(0, 1) + "."));
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

                Users newUser = new Users
                {
                    FirstName = txbFirstName.Text,
                    SecondName = txbSecondName.Text,
                    ThirdName = string.IsNullOrEmpty(txbThirdName.Text) ? null : txbThirdName.Text,
                    DivisionId = selectedDivision.DivisionId,
                    Gender = cmbGender.SelectedIndex == 1
                };

                try
                {
                    DBContext.db.Users.Add(newUser);
                    DBContext.db.SaveChanges();
                    MessageBox.Show("Пользователь успешно добавлен!");
                    ClearFields();

                    Logger.Trace($"Администратор добавил нового пользователя id:{newUser.UserId}", currentUser);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, currentUser);
                    MessageBox.Show(ex.Message);
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
