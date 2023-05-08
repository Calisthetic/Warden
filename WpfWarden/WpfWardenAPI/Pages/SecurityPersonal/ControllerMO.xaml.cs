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
        private Users currentUser = new Users();
        private List<Logs> logs = new List<Logs>();
        private int logsOnPage = 12;
        private int pagesCount;
        private int currentPageNumber = 0;


        List<Users> usersToBlock = new List<Users>();

        public ControllerMO(Users _currentUser)
        {
            InitializeComponent();
            if (_currentUser != null)
                currentUser = _currentUser;

            var logLevels = new List<Logs>
                {
                    new Logs { LogLevel = "Log level" },
                    new Logs { LogLevel = "Trace" },
                    new Logs { LogLevel = "Fatal" },
                    new Logs { LogLevel = "Error" },
                    new Logs { LogLevel = "Debug" },
                    new Logs { LogLevel = "Warn" },
                    new Logs { LogLevel = "Info" }
                };
            cmbLogLevels.ItemsSource = logLevels;
            cmbLogLevels.SelectedIndex = 0;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                //usersToBlock = DBContext.db.Users.Where(x => x.IsBlocked == false).ToList();
                //DGUsers.ItemsSource = usersToBlock;

                txtFIO.Text = currentUser.SecondName + " " + currentUser.FirstName.Substring(0, 1) + ". " +
                    ((currentUser.ThirdName == null) ? (" ") : (currentUser.ThirdName.Substring(0, 1) + "."));

                var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:54491/api/");
                var responseTask = client.GetAsync("Logs?skip=0&take=1000");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var resultString = readTask.Result;

                    logs = JsonConvert.DeserializeObject<List<Logs>>(resultString);
                }
                else
                    MessageBox.Show("Невозможно получить данные");

                //string result = APIContext.Get("Logs");
                //MessageBox.Show(result);
                //if (string.IsNullOrEmpty(result))
                //    MessageBox.Show("Невозможно получить данные");
                //else
                //    logs = JsonConvert.DeserializeObject<List<Logs>>(result); //DBContext.db.Logs.OrderByDescending(x => x.Logged).Skip(1).ToList();

                pagesCount = (logs.Count() % logsOnPage == 0) ? (logs.Count() / logsOnPage) : ((logs.Count() / logsOnPage) + 1);
                RefreshData();
            }
        }

        private void RefreshData()
        {
            DGLogs.ItemsSource = logs.Skip(currentPageNumber * logsOnPage).Take(logsOnPage);
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
                    if (usersToBlock[i].IsBlocked == true)
                    {
                        blockedUsersCount++;
                    }
                }
                if (blockedUsersCount > 0)
                {
                    //DBContext.db.SaveChanges();
                    //MessageBox.Show("Пользователи заблокированы");
                    //usersToBlock = DBContext.db.Users.Where(x => x.IsBlocked == false).ToList();
                    //DGUsers.ItemsSource = usersToBlock;
                    //RefreshData();

                    //Logger.Warn($"Контролёр МО заблокировал {blockedUsersCount} пользователей", currentUser);
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
            //logs = DBContext.db.Logs.Take(DBContext.db.Logs.Count() - 1).ToList();
            //if (cmbLogLevels.SelectedIndex != 0) // Sort by log level
            //{
            //    Logs selectedLogLevel = cmbLogLevels.SelectedItem as Logs;
            //    string levelName = (selectedLogLevel == null) ? ("") : (selectedLogLevel.LogLevel);
            //    logs = logs.Where(x => x.LogLevel == levelName).ToList();
            //}
            //if (ckbShowOld.IsChecked == true) // Sort by date
            //    logs = logs.OrderBy(x => x.Logged).ToList();
            //else
            //    logs = logs.OrderByDescending(x => x.Logged).ToList();

            //if (int.TryParse(txbUserId.Text, out int result) && result >= 0) // Fing by userId
            //{
            //    logs = logs.Where(x => x.UserId == result).ToList();
            //}
            //if (!string.IsNullOrWhiteSpace(txbSearchInMessage.Text)) // Search in message or exception
            //{
            //    logs = logs.Where(x => (x.Exception == null) ? (x.Message.ToLower().Contains(txbSearchInMessage.Text.ToLower())) // if Exception == null
            //    : ((x.Message == null) ? (x.Exception.ToLower().Contains(txbSearchInMessage.Text.ToLower())) // if Message == null
            //    : (x.Message.ToLower().Contains(txbSearchInMessage.Text.ToLower()) || x.Exception.ToLower().Contains(txbSearchInMessage.Text.ToLower())))).ToList();
            //}
            //currentPageNumber = 0;
            //pagesCount = (logs.Count() % logsOnPage == 0) ? (logs.Count() / logsOnPage) : ((logs.Count() / logsOnPage) + 1);
            //RefreshData();
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
