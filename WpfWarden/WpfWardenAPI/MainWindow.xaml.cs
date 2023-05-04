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

namespace WpfWardenAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PageManager.MainFrame = MainFrame;
            PageManager.MainFrame.Navigate(new Pages.AuthPages.DefaultAuthPage());

        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (PageManager.MainFrame.CanGoBack)
                btnBack.Visibility = Visibility.Visible;
            else
                btnBack.Visibility = Visibility.Collapsed;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PageManager.MainFrame.GoBack();
            if (MainFrame.Content.GetType().ToString().Split('.')[3] == "BlockedUserInfo")
            {
                //Classes.Logger.Logger.Trace("Специалист по ИБ покинул страницу диалога с пользователем", Pages.SecurityPersonal.BlockedUserInfo.currentUser);
            }
        }
    }
}
