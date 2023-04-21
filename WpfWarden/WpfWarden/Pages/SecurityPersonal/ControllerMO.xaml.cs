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

namespace WpfWarden.Pages.SecurityPersonal
{
    /// <summary>
    /// Логика взаимодействия для ControllerMO.xaml
    /// </summary>
    public partial class ControllerMO : Page
    {
        private Users currentUser = new Users();
        private List<Logs> logs= new List<Logs>();
        private int logsOnPage = 10;
        private int pagesCount;
        private int currentPageNumber = 0;


        List<Users> usersToBlock = new List<Users>();

        public ControllerMO(Users _currentUser)
        {
            InitializeComponent();
            if (_currentUser != null)
                currentUser = _currentUser;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                RefreshData();
                usersToBlock = DBContext.db.Users.OrderByDescending(x => x.IsBlocked).ToList();
                DGUsers.ItemsSource = usersToBlock;
            }
        }

        private void RefreshData()
        {
            logs = DBContext.db.Logs.OrderByDescending(x => x.Logged).ToList();
            pagesCount = (logs.Count() % logsOnPage == 0) ? (logs.Count() / logsOnPage) : ((logs.Count() / logsOnPage) + 1);
            txtFIO.Text = currentUser.SecondName + " " + currentUser.FirstName.Substring(0, 1) + ". " +
                ((currentUser.ThirdName == null) ? (" ") : (currentUser.ThirdName.Substring(0, 1) + "."));

            RefreshGrid();
        }
        private void RefreshGrid()
        {
            DGLogs.ItemsSource = logs.Skip(currentPageNumber * logsOnPage).Take(logsOnPage).ToList();
            txbPageNow.Text = (currentPageNumber + 1).ToString();
        }

        private void btnPagePlus_Click(object sender, RoutedEventArgs e)
        {
            if (currentPageNumber < pagesCount - 1)
            {
                currentPageNumber++;
                RefreshGrid();
            }
        }
        private void btnPageMinus_Click(object sender, RoutedEventArgs e)
        {
            if (currentPageNumber > 0)
            {
                currentPageNumber--;
                RefreshGrid();
            }
        }



        private void btnBlock_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int blockedUsersCount = 0;
                for (int i = 0; i < usersToBlock.Count; i++)
                {
                    if (usersToBlock[i].IsBlocked == true)
                    {
                        blockedUsersCount++;
                    }
                }
                if (blockedUsersCount > 0)
                {
                    DBContext.db.SaveChanges();
                    MessageBox.Show("Пользователи заблокированы");
                    usersToBlock = DBContext.db.Users.OrderBy(x => x.IsBlocked).ToList();
                    DGUsers.ItemsSource = usersToBlock;
                    RefreshGrid();

                    Logger.Trace($"Контролёр МО заблокировал {blockedUsersCount} пользователей");
                }
                else
                {
                    MessageBox.Show("Выберите пользователей на блокировку");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, currentUser);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
