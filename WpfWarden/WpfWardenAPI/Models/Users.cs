using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfWardenAPI.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string SecretWord { get; set; }
        public string DivisionName { get; set; }
        public string PermissionName { get; set; }
        public bool IsBlocked { get; set; }
        public bool Gender { get; set; }
        public bool IsVerify { get; set; }
        public string IsVerifyText { get; set; }
    }
}
