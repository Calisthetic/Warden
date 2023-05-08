using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiWarden.Models
{
    public class UserResponse
    {
        public UserResponse(Users user)
        {
            this.UserId = user.UserId;
            this.FirstName = user.FirstName;
            this.SecondName = user.SecondName;
            this.ThirdName = user.ThirdName;
            this.Password = user.Password;
            this.Login = user.Login;
            this.SecretWord = user.SecretWord;
            this.DivisionName = user.Division.Name;
            this.PermissionName = (user.Permission == null)?(null):(user.Permission.Name);
            this.IsBlocked = user.IsBlocked;
            this.IsVerify = user.IsVerify;
            this.Gender = user.Gender;
            this.IsVerifyText = user.IsVerify ? "Верифицирован" : "Не верифицирован";
        }

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