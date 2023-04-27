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
    /// Логика взаимодействия для BlockedUserInfo.xaml
    /// </summary>
    public partial class BlockedUserInfo : Page
    {
        public static Users currentUser = new Users();
        private Users checkedUser = new Users();
        private double currentScrollHeight = 0;

        public BlockedUserInfo(Users _currentUser, Users _checkedUser)
        {
            InitializeComponent();
            if (_currentUser != null)
                currentUser = _currentUser;
            if (_checkedUser != null)
                checkedUser = _checkedUser;
            try
            {
                if (checkedUser.Division.Name != null && checkedUser != null)
                {
                    ((MainWindow)Application.Current.MainWindow).txtTitle.Text = checkedUser.SecondName + " " + checkedUser.FirstName + " - " + checkedUser.Division.Name;
                    ((MainWindow)Application.Current.MainWindow).txtTitle.FontSize = 26;
                }
            } catch { }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                txbMessageText.Text = string.Empty;
                RefreshData();
            }
        }

        private void RefreshData()
        {
            LVMessages.ItemsSource = DBContext.db.BlockedUserMessages.Where(x => 
                (x.DestinationUserId == checkedUser.UserId) || (x.SendlerUserId == checkedUser.UserId)).ToList();
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
                MessageBox.Show($"В вашем сообщении слишком много символов {txbMessageText.Text} > 255");
            }
            else
            {
                BlockedUserMessages newMessage = new BlockedUserMessages();
                newMessage.SendlerUserId = currentUser.UserId;
                newMessage.DestinationUserId = checkedUser.UserId;
                newMessage.Message = txbMessageText.Text;
                DBContext.db.BlockedUserMessages.Add(newMessage);
                try
                {
                    DBContext.db.SaveChanges();

                    Logger.Trace($"Сотрудник ИБ отправил сообщение пользователю {checkedUser.UserId}: {txbMessageText.Text}", currentUser);
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

        private void cmbActions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbActions.SelectedIndex == 1) 
            { 
                try
                {
                    if (MessageBox.Show("Вы действительно хотите разблокировать данного пользователя?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        checkedUser.IsBlocked = false;
                        DBContext.db.SaveChanges();

                        MessageBox.Show("Пользователь разблокирован");
                        Logger.Trace($"Специалист по ИБ разблокировал пользователя с кодом {checkedUser.UserId}", currentUser);
                        PageManager.MainFrame.GoBack();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                    Logger.Error(ex, currentUser);
                }
            }
            else if (cmbActions.SelectedIndex == 2)
            {
                try
                {
                    if (MessageBox.Show("Вы действительно хотите удалить пользователя и все упоминания о нём?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        var deletedUserMessages = DBContext.db.BlockedUserMessages.Where(x => x.DestinationUserId == checkedUser.UserId || x.SendlerUserId == checkedUser.UserId).ToList();
                        for (int i = 0; i < deletedUserMessages.Count; i++)
                        {
                            DBContext.db.BlockedUserMessages.Remove(deletedUserMessages[i]);
                        }
                        var deletedUserLogs = DBContext.db.Logs.Where(x => x.UserId == checkedUser.UserId).ToList();
                        for (int i = 0; i < deletedUserLogs.Count; i++)
                        {
                            DBContext.db.Logs.Remove(deletedUserLogs[i]);
                        }
                        DBContext.db.Users.Remove(checkedUser);
                        DBContext.db.SaveChanges();
                        checkedUser = null;

                        MessageBox.Show("Пользователь и все его данные удалены");
                        Logger.Warn($"Специалист по ИБ удалил пользователя с кодом {checkedUser.UserId}", currentUser);
                        PageManager.MainFrame.GoBack();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                    Logger.Error(ex, currentUser);
                }
            }
            cmbActions.SelectedIndex = 0;
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
