using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfWardenAPI.Models
{
    internal class ResponseUsersMessage
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string DivisionName { get; set; }
        public string PermissionName { get; set; }
        public string IsVerifyText { get; set; }
        public Nullable<int> UncheckedMessagesCount { get; set; }
        public string LastMessage { get; set; }
        public System.DateTime LastMessageTime { get; set; }
    }
}
