using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiWarden.Models
{
    public class Messages
    {
        public Messages(BlockedUserMessages message) {
            BlockedUserMessageId = message.BlockedUserMessageId;
            SendlerIsBlocked = message.Users.IsBlocked;
            Message = message.Message;
            Time = message.Time;
        }
        public int BlockedUserMessageId { get; set; }
        //public int SendlerUserId { get; set; }
        public bool SendlerIsBlocked { get; set; }
        public string Message { get; set; }
        public System.DateTime Time { get; set; }
    }
}