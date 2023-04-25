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
using WpfWarden.Classes.Logger;
using WpfWarden.Models;

namespace WpfWarden.Pages.AuthPages
{
    /// <summary>
    /// Логика взаимодействия для DefaultAuthPage.xaml
    /// </summary>
    public partial class DefaultAuthPage : Page
    {
        public DefaultAuthPage()
        {
            InitializeComponent();
        }

        private void btnForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            Classes.PageManager.MainFrame.Navigate(new ForgotPasswordPage());
            Logger.Trace("Пользователь перешёл на страницу входа без пароля");
        }

        private void btnEntry_Click(object sender, RoutedEventArgs e)
        {
            Division selectedDivision = cmbDivisions.SelectedItem as Division;
            Users currentUser = Classes.DBContext.db.Users.FirstOrDefault(x => x.IsVerify == true && 
                x.Login == txbLogin.Text && x.Password == psbPassword.Password && x.DivisionId == selectedDivision.DivisionId);
            if (currentUser != null)
                Authorizating.Entry(currentUser);
            else
                MessageBox.Show("Пользователь не найден!\nВозможно данные были введены некорректно");
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                cmbDivisions.ItemsSource = DBContext.db.Division.ToList();
                cmbDivisions.SelectedIndex = 1;
                txbLogin.Text = string.Empty;
                ((MainWindow)Application.Current.MainWindow).txtTitle.Text = "Warden";
                ((MainWindow)Application.Current.MainWindow).txtTitle.FontSize = 30;
            }
        }
    }
}
