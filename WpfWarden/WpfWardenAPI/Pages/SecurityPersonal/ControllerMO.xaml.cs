using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    /// Логика взаимодействия для ControllerMO.xaml
    /// </summary>
    public partial class ControllerMO : Page
    {
        private User currentUser = new();

        private StringBuilder urlPath = new();
        private int logsOnPage = 12;
        private int pagesCount;
        private int currentPageNumber = 0;

        List<User> usersToBlockPoint = new List<User>();
        List<User> usersToBlock = new List<User>();

        public ControllerMO(User _currentUser)
        {
            InitializeComponent();
            if (_currentUser != null)
                currentUser = _currentUser;

            var logLevels = new List<Log>
                {
                    new Log { logLevel = "Log level" },
                    new Log { logLevel = "Trace" },
                    new Log { logLevel = "Fatal" },
                    new Log { logLevel = "Error" },
                    new Log { logLevel = "Debug" },
                    new Log { logLevel = "Warn" },
                    new Log { logLevel = "Info" }
                };
            cmbLogLevels.ItemsSource = logLevels;
            cmbLogLevels.SelectedIndex = 0;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                string notBlockedUsers = APIContext.Get("Users?IsBlocked=false");
                if (!string.IsNullOrEmpty(notBlockedUsers))
                {
                    usersToBlock = JsonConvert.DeserializeObject<List<User>>(notBlockedUsers);
                    DGUsers.ItemsSource = usersToBlock;
                }
                txtFIO.Text = currentUser.secondName + " " + currentUser.firstName.Substring(0, 1) + ". " +
                    ((currentUser.thirdName == null) ? (" ") : (currentUser.thirdName.Substring(0, 1) + "."));

                RefreshData();
            }
        }

        private void RefreshData()
        {
            string currentLogs = APIContext.Get($"Logs?skip={currentPageNumber * logsOnPage}&take={logsOnPage}{urlPath}");
            if (!string.IsNullOrEmpty(currentLogs))
            {
                DGLogs.ItemsSource = JsonConvert.DeserializeObject<List<Log>>(currentLogs);
            }
            txbPageNow.Text = (currentPageNumber + 1) + "/" + pagesCount;
        }

        private void btnPagePlus_Click(object sender, RoutedEventArgs e)
        {
            if (currentPageNumber < pagesCount - 1)
            {
                currentPageNumber++;
                RefreshData();
            }
        }
        private void btnPageMinus_Click(object sender, RoutedEventArgs e)
        {
            if (currentPageNumber > 0)
            {
                currentPageNumber--;
                RefreshData();
            }
        }



        private void btnBlock_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int blockedUsersCount = 0;
                for (int i = 0; i < usersToBlock.Count; i++)
                {
                    if (usersToBlock[i].isBlocked == true)
                    {
                        blockedUsersCount++;
                    }
                }
                if (blockedUsersCount > 0)
                {
                    bool error = false;
                    for (int i = 0; i < usersToBlock.Count; i++)
                    {
                        if (usersToBlock[i].isBlocked)
                        {
                            var json = JsonConvert.SerializeObject(usersToBlock[i]);
                            string putResult = APIContext.Put("Users/" + usersToBlock[i].userId, json);
                            if (string.IsNullOrEmpty(putResult))
                                error = true;
                        }
                    }
                    if (!error)
                        MessageBox.Show("Пользователи заблокированы");
                    else 
                        MessageBox.Show("Сохранить изменения не получилось");

                    string result = APIContext.Get("Users?IsBlocked=false");
                    if (string.IsNullOrEmpty(result))
                    {
                        MessageBox.Show("Не удалось обновить список пользователей");
                    } else
                    {
                        usersToBlock = JsonConvert.DeserializeObject<List<User>>(result);
                        DGUsers.ItemsSource = usersToBlock;
                    }
                    RefreshData();

                    Logger.Warn($"Контролёр МО заблокировал {blockedUsersCount} пользователей", currentUser);
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

        private void SearchLog()
        {
            urlPath.Clear();

            if (cmbLogLevels.SelectedIndex != 0) // Sort by log level
            {
                Log selectedLogLevel = cmbLogLevels.SelectedItem as Log;
                if (selectedLogLevel != null)
                    urlPath.Append($"&logLevel={selectedLogLevel.logLevel}");
            }
            if (ckbShowOld.IsChecked == true) // Sort by date
                urlPath.Append($"&showOld=true");

            if (int.TryParse(txbUserId.Text, out int result) && result >= 0) // Fing by userId
                urlPath.Append($"&userId={result}");

            if (!string.IsNullOrWhiteSpace(txbSearchInMessage.Text)) // Search in message or exception
                urlPath.Append($"&search={txbSearchInMessage.Text}");



            string currentLogsCount = APIContext.Get($"Logs/Count?skip=0" + urlPath);
            if (!string.IsNullOrEmpty(currentLogsCount) && int.TryParse(currentLogsCount, out int logsCount))
            {
                currentPageNumber = 0;
                pagesCount = (logsCount % logsOnPage == 0) ? (logsCount / logsOnPage) : ((logsCount / logsOnPage) + 1);
            }

            RefreshData();
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
        private void txbSearchInMessage_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchLog();
        }
    }
}
