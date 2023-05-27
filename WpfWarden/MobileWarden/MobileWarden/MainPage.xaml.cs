using MobileWarden.Classes;
using MobileWarden.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileWarden
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            string result = APIContext.Get("Divisions");
            if (!string.IsNullOrEmpty(result))
            {
                IList<Divisions> resultList = JsonConvert.DeserializeObject<IList<Models.Divisions>>(result);
                IList<string> resultList2 = new List<string>();
                foreach (Divisions division in resultList)
                {
                    resultList2.Add(division.Name);
                }
                pickerDivisions.ItemsSource = resultList2 as List<string>;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            APIContext.Get("Divisions");
        }
    }
}
