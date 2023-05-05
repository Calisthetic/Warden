using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfWardenAPI.Models
{
    internal class ResponseMessages
    {
        public int BlockedUserMessageId { get; set; }
        //public int SendlerUserId { get; set; }
        public bool SendlerIsBlocked { get; set; }
        public string Message { get; set; }
        public System.DateTime Time { get; set; }
    }
}
