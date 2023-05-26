using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiWarden.Models
{
    public class ResponseUsersMessage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ResponseUsersMessage(Users user)
        {
            UserId = user.UserId;
            FirstName = user.FirstName;
            SecondName = user.SecondName;
            ThirdName = user.ThirdName;
            DivisionName = user.Division.Name;
            PermissionName = user.Permission.Name;
            IsVerifyText = (user.IsVerify) ? ("Верифицирован") : ("Не верифицирован");
            //UncheckedMessagesCount = Classes.DBContext.db.Logs.AsEnumerable().Where(x => x.Message.Contains($"Сотрудник ИБ перешёл на страницу переписки с пользователем {user.UserId} из чёрного списка") == true).Count();
            UncheckedMessagesCount = (Classes.DBContext.db.Logs.AsEnumerable().Where(x => x.Message.Contains($"Сотрудник ИБ перешёл на страницу переписки с пользователем {user.UserId} из чёрного списка") == true).Count() == 0)
                ? (Classes.DBContext.db.BlockedUserMessages.AsEnumerable().Where(x1 => x1.SendlerUserId == user.UserId).Count())
                : (Classes.DBContext.db.BlockedUserMessages.AsEnumerable().Where(
                    x => x.Time > Classes.DBContext.db.Logs.AsEnumerable().Where(x1 => x1.Message.Contains($"Сотрудник ИБ перешёл на страницу переписки с пользователем {user.UserId} из чёрного списка") == true).OrderByDescending(x2 => x2.Logged).FirstOrDefault().Logged
                && x.SendlerUserId == user.UserId).Count());
            LastMessage = (Classes.DBContext.db.BlockedUserMessages.Where(x => x.SendlerUserId == user.UserId || x.DestinationUserId == user.UserId).OrderByDescending(x => x.Time).Count() == 0)
                ? ("Пока что здесь нет сообщений...")
                : (Classes.DBContext.db.BlockedUserMessages.Where(x => x.SendlerUserId == user.UserId || x.DestinationUserId == user.UserId).OrderByDescending(x => x.Time).First().Message);
            LastMessageTime = (Classes.DBContext.db.BlockedUserMessages.Where(x => x.SendlerUserId == user.UserId || x.DestinationUserId == user.UserId).OrderByDescending(x => x.Time).Count() == 0)
                ? new DateTime(2000, 1, 1, 1, 1, 1)
                : (Classes.DBContext.db.BlockedUserMessages.Where(x => x.SendlerUserId == user.UserId || x.DestinationUserId == user.UserId).OrderByDescending(x => x.Time).First().Time);
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        //public string DivisionName { get { return Division.Name; } set { this.DivisionName = value; } }
        public string DivisionName { get; set; }
        //public Nullable<int> PermissionId { get; set; }
        public string PermissionName { get; set; }
        //public bool IsVerify { get; set; }
        public string IsVerifyText { get; set; }
        //public int UncheckedMessagesCount
        //{
        //    get
        //    {
        //        // Последнее время входа сотрудника ИБ
        //        // DateTime lastLogged = Classes.DBContext.db.Logs.Where(x => x.Users.Permission.Name == "Специалист по ИБ").OrderByDescending(x => x.Logged).Skip(1).FirstOrDefault().Logged;
        //        // Если Сотрудник по ИБ никогда не заходил на страницу
        //        if (Classes.DBContext.db.Logs.AsEnumerable().Where(x => x.Message.Contains($"Сотрудник ИБ перешёл на страницу переписки с пользователем {UserId} из чёрного списка") == true).Count() == 0)
        //            return Classes.DBContext.db.BlockedUserMessages.Where(x => x.SendlerUserId == UserId).Count();
        //        DateTime lastLogged = Classes.DBContext.db.Logs.AsEnumerable().Where(x => x.Message.Contains($"Сотрудник ИБ перешёл на страницу переписки с пользователем {UserId} из чёрного списка") == true).OrderByDescending(x => x.Logged).FirstOrDefault().Logged;
        //        // Кол-во сообщений с того времени
        //        return Classes.DBContext.db.BlockedUserMessages.Where(x => x.Time > lastLogged && x.SendlerUserId == UserId).Count();
        //    }
        //    set { this.UncheckedMessagesCount = value; }
        //}
        public Nullable<int> UncheckedMessagesCount { get; set; }
        //public string LastMessage
        //{
        //    get
        //    {
        //        if (Classes.DBContext.db.BlockedUserMessages.Where(x => x.SendlerUserId == UserId || x.DestinationUserId == UserId).OrderByDescending(x => x.Time).Count() == 0)
        //            return "Пока что здесь нет сообщений...";
        //        return Classes.DBContext.db.BlockedUserMessages.Where(x => x.SendlerUserId == UserId || x.DestinationUserId == UserId).OrderByDescending(x => x.Time).First().Message;
        //    }
        //    set { this.LastMessage = value; }
        //}
        public string LastMessage { get; set; }
        public Nullable<System.DateTime> LastMessageTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<BlockedUserMessages> BlockedUserMessages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<BlockedUserMessages> BlockedUserMessages1 { get; set; }
        [JsonIgnore]
        public virtual Division Division { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Logs> Logs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Order> Order { get; set; }
        [JsonIgnore]
        public virtual Permission Permission { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<ProductEnterAct> ProductEnterAct { get; set; }
    }
}