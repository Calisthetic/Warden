using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfWardenAPI.Models;

namespace WpfWardenAPI.Classes.Logger
{
    internal class Logger
    {
        public static void Info(string message, User user)
        {
            Log log = new Log();
            log.message = message;
            log.logLevel = LogLevel.Info;
            log.userId = user.userId;
            PushLog(log);
        }
        public static void Error(Exception ex, User user)
        {
            Log log = new Log();
            log.exception = ex.Message;
            log.logLevel = LogLevel.Error;
            log.userId = user.userId;
            PushLog(log);
        }
        public static void Trace(string message)
        {
            Log log = new Log();
            log.message = message;
            log.logLevel = LogLevel.Trace;
            PushLog(log);
        }
        public static void Trace(string message, User user)
        {
            Log log = new Log();
            log.message = message;
            log.logLevel = LogLevel.Trace;
            log.userId = user.userId;
            PushLog(log);
        }
        public static void Warn(string message, User user)
        {
            Log log = new Log();
            log.message = message;
            log.logLevel = LogLevel.Warn;
            log.userId = user.userId;
            PushLog(log);
        }
        public static void Debug(string message)
        {
            Log log = new Log();
            log.message = message;
            log.logLevel = LogLevel.Debug;
            PushLog(log);
        }

        private static void PushLog(Log log)
        {
            try
            {
                log.machineName = "WpfWardenAPI";
                log.logged = DateTime.Now;
                string result = APIContext.Post("Logs", JsonConvert.SerializeObject(log));
            } catch { }
            //try
            //{
            //    DBContext.db.Logs.Add(log);
            //    DBContext.db.SaveChanges();
            //}
            //catch (DbEntityValidationException er)
            //{
            //    foreach (var eve in er.EntityValidationErrors)
            //    {
            //        MessageBox.Show("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:" +
            //            eve.Entry.Entity.GetType().Name + eve.Entry.State);
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            MessageBox.Show("- Property: \"{0}\", Error: \"{1}\"" +
            //                ve.PropertyName + ve.ErrorMessage);
            //        }
            //    }
            //}
        }
    }
}
