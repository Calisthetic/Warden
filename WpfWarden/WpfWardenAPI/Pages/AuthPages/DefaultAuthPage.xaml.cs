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

namespace WpfWardenAPI.Pages.AuthPages
{
    /// <summary>
    /// Логика взаимодействия для DefaultAuthPage.xaml
    /// </summary>
    public partial class DefaultAuthPage : Page
    {
        public DefaultAuthPage()
        {
            InitializeComponent();
        }

        private void btnForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            Classes.PageManager.MainFrame.Navigate(new ForgotPasswordPage());
            Logger.Trace("Пользователь перешёл на страницу входа без пароля");
        }

        private async void btnEntry_Click(object sender, RoutedEventArgs e)
        {
            Division selectedDivision = cmbDivisions.SelectedItem as Division;

            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:54491/api/");
                var responseTask = client.GetAsync("Users?login=" + txbLogin.Text + "&password=" + psbPassword.Password + "&divisionId=" + selectedDivision.DivisionId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var resultString = readTask.Result;

                    Users currentUser = JsonConvert.DeserializeObject<Users>(resultString);
                    if (currentUser != null)
                        Classes.Authorizating.Entry(currentUser);
                    else
                        MessageBox.Show("Пользователь не найден!\nКажется что-то пошло не так...");
                }
                else 
                    MessageBox.Show("Пользователь не найден!\nВозможно данные были введены некорректно");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                try
                {
                    var client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:54491/api/");
                    var responseTask = client.GetAsync("Divisions");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait();

                        var resultString = readTask.Result;

                        cmbDivisions.ItemsSource = JsonConvert.DeserializeObject<List<Division>>(resultString);
                        cmbDivisions.SelectedIndex = 1;
                    }
                    else
                        MessageBox.Show("Не получилось найти данные...");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

                txbLogin.Text = string.Empty;
                psbPassword.Password = string.Empty;
                if (Application.Current.MainWindow != null)
                {
                    ((MainWindow)Application.Current.MainWindow).txtTitle.Text = "Warden";
                    ((MainWindow)Application.Current.MainWindow).txtTitle.FontSize = 30;
                }
            }
        }
    }
}
