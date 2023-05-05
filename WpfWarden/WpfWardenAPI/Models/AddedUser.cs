﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfWardenAPI.Models
{
    internal class AddedUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string SecretWord { get; set; }
        public int DivisionId { get; set; }
        public Nullable<int> PermissionId { get; set; }
        public bool IsBlocked { get; set; }
        public bool Gender { get; set; }
        public bool IsVerify { get; set; }
    }
}
