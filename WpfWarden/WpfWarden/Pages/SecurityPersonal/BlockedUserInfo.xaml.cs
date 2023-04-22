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
        private Users currentUser = new Users();
        private Users checkedUser = new Users();

        public BlockedUserInfo(Users _currentUser, Users _checkedUser)
        {
            InitializeComponent();
            if (_currentUser != null)
                currentUser = _currentUser;
            if (_checkedUser != null)
                checkedUser = _checkedUser;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                txtFIO.Text = currentUser.SecondName + " " + currentUser.FirstName.Substring(0, 1) + ". " +
                    ((currentUser.ThirdName == null) ? (" ") : (currentUser.ThirdName.Substring(0, 1) + "."));
                txtBlockedUserFIO.Text = "Заблокированный пользователь: " + checkedUser.SecondName + " " + checkedUser.FirstName + " " +
                    ((checkedUser.ThirdName == null) ? (" ") : (checkedUser.ThirdName));
                txbMessageText.Text = string.Empty;
            }
            RefreshData();
        }

        private void RefreshData()
        {
            LVMessages.ItemsSource = DBContext.db.BlockedUserMessages.Where(x => 
                (x.DestinationUserId == checkedUser.UserId) || (x.SendlerUserId == checkedUser.UserId)).ToList();
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
            }
        }
    }
}
