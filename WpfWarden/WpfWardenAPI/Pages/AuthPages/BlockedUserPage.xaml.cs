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
using WpfWardenAPI.Classes;
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
            var result = APIContext.Get("BlockedUserMessages/" + currentUser.userId);
                
            if (!string.IsNullOrEmpty(result))
            {
                LVMessages.ItemsSource = JsonConvert.DeserializeObject<List<BlockedUserMessage>>(result);
            }
            else MessageBox.Show("Не получилось найти данные...");
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
                BlockedUserMessage newMessage = new BlockedUserMessage();
                newMessage.SendlerUserId = currentUser.userId;
                newMessage.Message = txbMessageText.Text;
                newMessage.Time = DateTime.Now;

                var result = APIContext.Post("BlockedUserMessages", JsonConvert.SerializeObject(newMessage));

                if (!string.IsNullOrEmpty(result))
                {
                    Logger.Trace($"Пользователь {currentUser.userId} отправил сообщение Сотруднику ИБ: {txbMessageText.Text}", currentUser);
                }
                else
                {
                    MessageBox.Show("Не удалось отправить сообщение");
                }

                RefreshData();
                txbMessageText.Text = string.Empty;
                var scrollViewer = FindName("ScrollMessages");
                ((ScrollViewer)scrollViewer)?.ScrollToBottom();
            }
        }

        private void btnDeleteMessage_Click(object sender, RoutedEventArgs e)
        {
            List<BlockedUserMessage> selectedMessages = LVMessages.SelectedItems.Cast<BlockedUserMessage>().ToList();
            if (MessageBox.Show($"Вы действительно хотите удалить эти сообщения в количестве {selectedMessages.Count()} штук?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    bool showError = false;
                    for (int i = 0; i < selectedMessages.Count; i++)
                    {
                        //if (selectedMessages[i].sendlerIsBlocked == false)
                        //{
                        //    showError = true;
                        //}
                    }

                    if (showError)
                        MessageBox.Show("Вы можете удалять только свои сообщения!");
                    else
                    {
                        for (int i = 0; i < selectedMessages.Count; i++)
                        {
                            var result = APIContext.Delete("BlockedUserMessages/" + selectedMessages[i].BlockedUserMessageId);

                            if (string.IsNullOrEmpty(result))
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
