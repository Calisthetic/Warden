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
    /// Логика взаимодействия для BlockedUserPage.xaml
    /// </summary>
    public partial class BlockedUserPage : Page
    {
        private Users currentUser = new Users();
        private double currentScrollHeight = 0;

        public BlockedUserPage(Users _currentUser)
        {
            InitializeComponent();
            if (_currentUser != null)
                currentUser = _currentUser;
            MessageBox.Show("Ваш аккаунт был заблокирован!\n" +
                "Свяжитесь с сотрудником поддержки в течение суток, либо будете заблокированы автоматически.");
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                txbMessageText.Text = string.Empty;
                RefreshData();
                ((MainWindow)Application.Current.MainWindow).txtTitle.Text = "Связь с сотрудником тех. поддержки";
                ((MainWindow)Application.Current.MainWindow).txtTitle.FontSize = 26;
            }
        }

        private void RefreshData()
        {
            LVMessages.ItemsSource = DBContext.db.BlockedUserMessages.Where(x =>
                (x.DestinationUserId == currentUser.UserId) || (x.SendlerUserId == currentUser.UserId)).ToList();
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
                DBContext.db.BlockedUserMessages.Add(newMessage);
                try
                {
                    DBContext.db.SaveChanges();

                    Logger.Trace($"Пользователь {currentUser.UserId} отправил сообщение Сотруднику ИБ: {txbMessageText.Text}", currentUser);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                    Logger.Error(ex, currentUser);
                }

                RefreshData();
                txbMessageText.Text = string.Empty;
                var scrollViewer = FindName("ScrollMessages");
                ((ScrollViewer)scrollViewer)?.ScrollToBottom();
            }
        }

        private void btnDeleteMessage_Click(object sender, RoutedEventArgs e)
        {
            List<BlockedUserMessages> selectedMessages = LVMessages.SelectedItems.Cast<BlockedUserMessages>().ToList();
            if (MessageBox.Show($"Вы действительно хотите удалить эти сообщения в количестве {selectedMessages.Count()} штук?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    bool showErr = false;
                    bool showSucc = false;
                    for (int i = 0; i < selectedMessages.Count; i++)
                    {
                        if (selectedMessages[i].SendlerUserId == currentUser.UserId)
                        {
                            DBContext.db.BlockedUserMessages.Remove(selectedMessages[i]);
                            showSucc = true;
                        }
                        else
                            showErr = true;
                    }
                    DBContext.db.SaveChanges();
                    if (showErr && showSucc)
                        MessageBox.Show("Вы можете удалять только свои сообщения!\nОстальные сообщения успешно удалены");
                    else if (showErr)
                        MessageBox.Show("Вы можете удалять только свои сообщения!");
                    else
                        MessageBox.Show("Остальные сообщения успешно удалены");
                    Logger.Trace($"Заблокированный пользователь удалил {selectedMessages.Count()} сообщений");
                    RefreshData();
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
