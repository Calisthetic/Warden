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

        public BlockedUserPage(Users _currentUser)
        {
            InitializeComponent();
            if (_currentUser != null)
                currentUser = _currentUser;
        }

        private void btnSendMessage_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbMessageText.Text))
            {
                MessageBox.Show("Введите сообщение");
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
            }
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
                (x.DestinationUserId == currentUser.UserId) || (x.SendlerUserId == currentUser.UserId)).ToList();
        }

        
    }
}
