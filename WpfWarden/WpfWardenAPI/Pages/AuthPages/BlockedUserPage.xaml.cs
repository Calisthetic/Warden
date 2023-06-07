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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfWardenAPI.Classes.Logger;
using WpfWardenAPI.Models;

namespace WpfWardenAPI.Pages.AuthPages
{
    /// <summary>
    /// Логика взаимодействия для BlockedUserPage.xaml
    /// </summary>
    public partial class BlockedUserPage : Page
    {
        private static User currentUser = new User();
        private double currentScrollHeight = 0;

        public BlockedUserPage(User _currentUser)
        {
            InitializeComponent();
            if (_currentUser != null)
                currentUser = _currentUser;
            MessageBox.Show("Ваш аккаунт был заблокирован!\n" +
                "Свяжитесь с сотрудником поддержки в течение суток, либо будете заблокированы автоматически.");
            RefreshData();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                txbMessageText.Text = string.Empty;
                ((MainWindow)Application.Current.MainWindow).txtTitle.Text = "Связь с сотрудником тех. поддержки";
                ((MainWindow)Application.Current.MainWindow).txtTitle.FontSize = 26;
            }
        }

        public void RefreshData()
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:54491/api/");
                var responseTask = client.GetAsync("Messages?userId=" + currentUser.userId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var resultString = readTask.Result;

                    LVMessages.ItemsSource = JsonConvert.DeserializeObject<List<BlockedUserMessage>>(resultString);
                }
                else MessageBox.Show("Не получилось найти данные...");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnSendMessage_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }
        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return")
                SendMessage();
        }
        private void SendMessage()
        {
            if (string.IsNullOrWhiteSpace(txbMessageText.Text))
            {
                MessageBox.Show("Введите сообщение");
            }
            else if (txbMessageText.Text.Length > 255)
            {
                MessageBox.Show($"В вашем сообщении слишком много символов {txbMessageText.Text.Length} > 255");
            }
            else
            {
                BlockedUserMessages newMessage = new BlockedUserMessages();
                newMessage.SendlerUserId = currentUser.UserId;
                newMessage.Message = txbMessageText.Text;
                newMessage.Time = DateTime.Now;

                try
                {
                    HttpClient client = new HttpClient();
                    var url = "http://localhost:54491/api/BlockedUserMessages";

                    var json = JsonConvert.SerializeObject(newMessage);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = client.PostAsync(url, data);
                    response.Wait();

                    if (response.Result.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        Logger.Trace($"Пользователь {currentUser.UserId} отправил сообщение Сотруднику ИБ: {txbMessageText.Text}", currentUser);
                    }
                    else
                    {
                        MessageBox.Show("Не удалось отправить сообщение");
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, currentUser);
                    MessageBox.Show(ex.Message);
                }

                RefreshData();
                txbMessageText.Text = string.Empty;
                var scrollViewer = FindName("ScrollMessages");
                ((ScrollViewer)scrollViewer)?.ScrollToBottom();
            }
        }

        private void btnDeleteMessage_Click(object sender, RoutedEventArgs e)
        {
            List<ResponseMessages> selectedMessages = LVMessages.SelectedItems.Cast<ResponseMessages>().ToList();
            if (MessageBox.Show($"Вы действительно хотите удалить эти сообщения в количестве {selectedMessages.Count()} штук?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    bool showError = false;
                    for (int i = 0; i < selectedMessages.Count; i++)
                    {
                        if (selectedMessages[i].SendlerIsBlocked == false)
                        {
                            showError = true;
                        }
                    }

                    if (showError)
                        MessageBox.Show("Вы можете удалять только свои сообщения!");
                    else
                    {
                        for (int i = 0; i < selectedMessages.Count; i++)
                        {
                            HttpClient client = new HttpClient();
                            var url = "http://localhost:54491/api/BlockedUserMessages/" + selectedMessages[i].BlockedUserMessageId;

                            var response = client.DeleteAsync(url);
                            response.Wait();

                            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                Logger.Trace($"Заблокированный пользователь удалил {selectedMessages.Count()} сообщений");
                                RefreshData();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, currentUser);
                }
            }
        }

        private void LVMessages_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var scrollViewer = FindName("ScrollMessages");
            currentScrollHeight -= e.Delta;
            if (currentScrollHeight < 0)
                currentScrollHeight = 0;
            if (currentScrollHeight > ((ScrollViewer)scrollViewer)?.ScrollableHeight)
                currentScrollHeight = (double)((ScrollViewer)scrollViewer)?.ScrollableHeight;
            ((ScrollViewer)scrollViewer)?.ScrollToVerticalOffset((int)currentScrollHeight);
        }
    }
}
