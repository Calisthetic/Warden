using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfWardenAPI.Models
{
    internal class UserMessagesCount
    {
        public int uncheckedMessagesCount { get; set; }

        public DateTime? uncheckedMessageTime { get; set; }

        public BlockedUserMessage userLastMessage { get; set; }

        public User sendlerUser { get; set; }
    }
}
