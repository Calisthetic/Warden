using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiWarden.Models
{
    public class ResponseLogs
    {
        public ResponseLogs(Logs log)
        {
            this.LogId = log.LogId;
            this.MachineName = log.MachineName;
            this.Logged = log.Logged;
            this.LogLevel = log.LogLevel;
            this.Message = log.Message;
            this.Exception = log.Exception;
            this.UserId = log.UserId;
            this.UserFirstName = (log.Users == null) ? (null) : (log.Users.FirstName);
            this.UserSecondName = (log.Users == null) ? (null) : (log.Users.SecondName);
            this.UserThirdName = (log.Users == null) ? (null) : (log.Users.ThirdName);
            this.UserDivisionName = (log.Users == null) ? (null) : (log.Users.Division.Name);
            this.UserIsVerify = (log.Users == null) ? (null) : ((log.Users.IsVerify) ? ("Верифицирован") : ("Не верифицирован"));
        }
        public int LogId { get; set; }
        public string MachineName { get; set; }
        public System.DateTime Logged { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public Nullable<int> UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserSecondName { get; set; }
        public string UserThirdName { get; set; }
        public string UserDivisionName { get; set; }
        public string UserIsVerify { get; set; }
    }
}