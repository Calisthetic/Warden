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
                usersToBlock = DBContext.db.Users.Where(x => x.IsBlocked == false).ToList();
                DGUsers.ItemsSource = usersToBlock;
                var logLevels = new List<Logs>();
                logLevels.Add(new Logs { LogLevel = "Log level" });
                logLevels.Add(new Logs { LogLevel = "Trace" });
                logLevels.Add(new Logs { LogLevel = "Fatal" });
                logLevels.Add(new Logs { LogLevel = "Error" });
                logLevels.Add(new Logs { LogLevel = "Debug" });
                logLevels.Add(new Logs { LogLevel = "Warn" });
                logLevels.Add(new Logs { LogLevel = "Info" });
                cmbLogLevels.ItemsSource = logLevels;
                cmbLogLevels.SelectedIndex = 0;
            }
        }

        private void RefreshData()
        {
            logs = DBContext.db.Logs.OrderByDescending(x => x.Logged).ToList();
            pagesCount = (logs.Count() % logsOnPage == 0) ? (logs.Count() / logsOnPage) : ((logs.Count() / logsOnPage) + 1);
            txtFIO.Text = currentUser.SecondName + " " + currentUser.FirstName.Substring(0, 1) + ". " +
                ((currentUser.ThirdName == null) ? (" ") : (currentUser.ThirdName.Substring(0, 1) + "."));

            RefreshLogsDataGrid();
        }
        private void RefreshLogsDataGrid()
        {
            DGLogs.ItemsSource = logs.Skip(currentPageNumber * logsOnPage).Take(logsOnPage).ToList();
            txbPageNow.Text = (currentPageNumber + 1).ToString();
        }

        private void btnPagePlus_Click(object sender, RoutedEventArgs e)
        {
            if (currentPageNumber < pagesCount - 1)
            {
                currentPageNumber++;
                RefreshLogsDataGrid();
            }
        }
        private void btnPageMinus_Click(object sender, RoutedEventArgs e)
        {
            if (currentPageNumber > 0)
            {
                currentPageNumber--;
                RefreshLogsDataGrid();
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
                    usersToBlock = DBContext.db.Users.Where(x => x.IsBlocked == false).ToList();
                    DGUsers.ItemsSource = usersToBlock;
                    RefreshData();

                    Logger.Trace($"Контролёр МО заблокировал {blockedUsersCount} пользователей", currentUser);
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

        private void cmbLogLevels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchLog();
        }

        private void txbUserId_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchLog();
        }

        private void ckbShowOld_Checked(object sender, RoutedEventArgs e)
        {
            SearchLog();
        }

        private void SearchLog()
        {
            logs = DBContext.db.Logs.ToList();
            if (cmbLogLevels.SelectedIndex != 0) // Sort by log level
            {
                Logs selectedLogLevel = cmbLogLevels.SelectedItem as Logs;
                string levelName = (selectedLogLevel == null) ? ("") : (selectedLogLevel.LogLevel);
                logs = logs.Where(x => x.LogLevel == levelName).ToList();
            }
            if (ckbShowOld.IsChecked == true) // Sort by date
                logs = logs.OrderBy(x => x.Logged).ToList();
            else
                logs = logs.OrderByDescending(x => x.Logged).ToList();

            if (int.TryParse(txbUserId.Text, out int result) && result >= 0) // Fing by userId
            {
                logs = logs.Where(x => x.UserId == result).ToList();
            }
            currentPageNumber = 0;
            RefreshLogsDataGrid();
        }
    }
}
