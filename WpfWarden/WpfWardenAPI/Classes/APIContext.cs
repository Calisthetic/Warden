using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace WpfWardenAPI.Classes
{
    class APIContext
    {
        private static string result;
        private static readonly string url = "http://localhost:54491/api/";
        public static async IAsyncEnumerable<string> GetString(string path)
        {
            HttpClient client = new HttpClient();
            result = await client.GetStringAsync(url + path);
            //MessageBox.Show(result);
            if (result != null)
                yield return result;
            else
                yield return "[]";
        }
        private static async void Push(string path)
        {
            HttpClient client = new HttpClient();
            result = await client.GetStringAsync(url + path);
        }
    }
}
