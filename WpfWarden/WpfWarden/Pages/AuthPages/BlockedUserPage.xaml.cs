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
using WpfWarden.Models;

namespace WpfWarden.Pages.AuthPages
{
    /// <summary>
    /// Логика взаимодействия для BlockedUserPage.xaml
    /// </summary>
    public partial class BlockedUserPage : Page
    {
        public BlockedUserPage(Users currentUser)
        {
            InitializeComponent();
        }
    }
}
