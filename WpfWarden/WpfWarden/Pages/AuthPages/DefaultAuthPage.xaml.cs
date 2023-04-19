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
        }

        private void btnEntry_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
