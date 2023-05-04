using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfWarden.Models;

namespace WpfWarden.Classes
{
    public class Authorizating
    {
        public static void Entry(Users currentUser)
        {
            if (!currentUser.IsBlocked)
            {
                switch (currentUser.Permission.Name)
                {
                    case "Администратор доступа":
                        Classes.PageManager.MainFrame.Navigate(new Pages.SecurityPersonal.AdministratorPage(currentUser));
                        Logger.Logger.Trace("Пользователь вошёл в систему", currentUser);
                        break;
                    case "Специалист по ИБ":
                        Classes.PageManager.MainFrame.Navigate(new Pages.SecurityPersonal.InfoSecurerPage(currentUser));
                        Logger.Logger.Trace("Пользователь вошёл в систему", currentUser);
                        break;
                    case "Контролёр МО":
                        Classes.PageManager.MainFrame.Navigate(new Pages.SecurityPersonal.ControllerMO(currentUser));
                        Logger.Logger.Trace("Пользователь вошёл в систему", currentUser);
                        break;
                    default:
                        MessageBox.Show("Не удалось определить ваши права доступа...");
                        break;
                }
            }
            else
            {
                Classes.PageManager.MainFrame.Navigate(new Pages.AuthPages.BlockedUserPage(currentUser));
                Logger.Logger.Trace("Заблокированный пользователь перешёл на страницу переписки", currentUser);
            }
        }
    }
}
