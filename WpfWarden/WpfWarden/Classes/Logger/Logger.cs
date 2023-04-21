using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfWarden.Models;

namespace WpfWarden.Classes.Logger
{
    public class Logger
    {
        public static void Info(string message, Users user)
        {
            Logs log = new Logs();
            log.Message = message;
            log.LogLevel = LogLevel.Info;
            log.UserId = user.UserId;
            PushLog(log);
        }
        public static void Error(Exception ex, Users user)
        {
            Logs log = new Logs();
            log.Exception = ex.Message;
            log.LogLevel = LogLevel.Error;
            log.UserId = user.UserId;
            PushLog(log);
        }
        public static void Trace(string message)
        {
            Logs log = new Logs();
            log.Message = message;
            log.LogLevel = LogLevel.Trace;
            PushLog(log);
        }
        public static void Trace(string message, Users user)
        {
            Logs log = new Logs();
            log.Message = message;
            log.LogLevel = LogLevel.Trace;
            log.UserId = user.UserId;
            PushLog(log);
        }
        public static void Warn(string message, Users user)
        {
            Logs log = new Logs();
            log.Message = message;
            log.LogLevel = LogLevel.Warn;
            log.UserId = user.UserId;
            PushLog(log);
        }
        public static void Debug(string message)
        {
            Logs log = new Logs();
            log.Message = message;
            log.LogLevel = LogLevel.Debug;
            PushLog(log);
        }

        private static void PushLog(Logs log)
        {
            try
            {
                DBContext.db.Logs.Add(log);
                DBContext.db.SaveChanges();
            }
            catch (DbEntityValidationException er)
            {
                foreach (var eve in er.EntityValidationErrors)
                {
                    MessageBox.Show("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:" +
                        eve.Entry.Entity.GetType().Name + eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        MessageBox.Show("- Property: \"{0}\", Error: \"{1}\"" +
                            ve.PropertyName + ve.ErrorMessage);
                    }
                }
            }
        }
    }
}
