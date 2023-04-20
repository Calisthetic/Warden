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

namespace WpfWarden.Pages.AuthPages
{
    /// <summary>
    /// Логика взаимодействия для ForgotPasswordPage.xaml
    /// </summary>
    public partial class ForgotPasswordPage : Page
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }

        private void btnEntry_Click(object sender, RoutedEventArgs e)
        {
            Division selectedDivision = cmbDivisions.SelectedItem as Division;
            string[] userNames = txbNames.Text.Split(' ');
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(txbNames.Text))
            {
                errors.AppendLine("Фамилия и Имя не введены");
            } 
            else if (txbNames.Text.Split(' ').Length != 2)
            {
                errors.AppendLine("Фамилия и Имя введены некорректно");
            }
            if (string.IsNullOrEmpty(txbSecretWord.Text))
            {
                errors.AppendLine("Секретное слово не было введено");
            }
            if (errors.Length == 0)
            {
                Users currentUser = Classes.DBContext.db.Users.FirstOrDefault(x => x.IsVerify == true && x.SecretWord == txbSecretWord.Text &&
                    x.FirstName == userNames[1] && x.SecondName == userNames[0] && x.DivisionId == selectedDivision.DivisionId);
                if (currentUser != null)
                    Authorizating.Entry(currentUser);
                else
                    MessageBox.Show("Пользователь не найден!\nВозможно данные были введены некорректно");
            }
            else
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                cmbDivisions.ItemsSource = Classes.DBContext.db.Division.ToList();
                cmbDivisions.SelectedIndex = 0;
            }
        }
    }
}
