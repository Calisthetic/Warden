using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfWardenAPI.Models
{
    class Logs
    {
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
