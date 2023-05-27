﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace MobileWarden.Classes
{
    public class APIContext
    {
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://127.0.0.1:54491/api/") };

        public static string Get(string urlPath)
        {
            try
            {
                var responseTask = client.GetAsync(urlPath);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var resultString = readTask.Result;
                    Debug.Fail(resultString);
                    Debug.WriteLine(resultString);
                    return resultString;
                }
                else
                    return string.Empty;
            }
            catch (Exception ex)
            {
                Debug.Fail(ex.Message);
                return string.Empty;
            }
        }
        public static string Post(string urlPath, string obj)
        {
            try
            {
                var responseTask = client.PostAsync(urlPath, new StringContent(obj, Encoding.UTF8, "application/json"));
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return "Success";
                    //var readTask = result.Content.ReadAsStringAsync();
                    //readTask.Wait();

                    //var resultString = readTask.Result;

                    //return resultString;
                }
                else
                    return string.Empty;
            }
            catch { return string.Empty; }
        }

        public static string Put(string urlPath, string obj)
        {
            try
            {
                var responseTask = client.PutAsync(urlPath, new StringContent(obj, Encoding.UTF8, "application/json"));
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.StatusCode == System.Net.HttpStatusCode.NoContent)
                    return "Success";
                else
                    return string.Empty;
            }
            catch { return string.Empty; }
        }
        public static string Delete(string urlPath)
        {
            try
            {
                var responseTask = client.DeleteAsync(urlPath);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    return "Success";
                else
                    return string.Empty;
            }
            catch { return string.Empty; }
        }
    }
}
