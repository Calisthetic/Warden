//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfWarden.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.BlockedUserMessages = new HashSet<BlockedUserMessages>();
            this.BlockedUserMessages1 = new HashSet<BlockedUserMessages>();
            this.Logs = new HashSet<Logs>();
            this.Order = new HashSet<Order>();
            this.ProductEnterAct = new HashSet<ProductEnterAct>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        [DefaultValue(null)]
        public string ThirdName { get; set; }
        [DefaultValue(null)]
        public string Login { get; set; }
        [DefaultValue(null)]
        public string Password { get; set; }
        [DefaultValue(null)]
        public string SecretWord { get; set; }
        public int DivisionId { get; set; }
        public Nullable<int> PermissionId { get; set; }
        [DefaultValue(false)]
        public bool IsBlocked { get; set; }
        public bool Gender { get; set; }
        [DefaultValue(false)]
        public bool IsVerify { get; set; }
        public string IsVerifyText
        {
            get
            {
                return (IsVerify) ? "Да" : "Нет";
            }
        }
        public int UncheckedMessagesCount { get
            {
                // Последнее время входа сотрудника ИБ
                // DateTime lastLogged = Classes.DBContext.db.Logs.Where(x => x.Users.Permission.Name == "Специалист по ИБ").OrderByDescending(x => x.Logged).Skip(1).FirstOrDefault().Logged;
                // Если Сотрудник по ИБ никогда не заходил на страницу
                if (Classes.DBContext.db.Logs.AsEnumerable().Where(x => x.Message.Contains($"Сотрудник ИБ перешёл на страницу переписки с пользователем {UserId} из чёрного списка") == true).Count() == 0)
                    return Classes.DBContext.db.BlockedUserMessages.Where(x => x.SendlerUserId == UserId).Count();
                DateTime lastLogged = Classes.DBContext.db.Logs.AsEnumerable().Where(x => x.Message.Contains($"Сотрудник ИБ перешёл на страницу переписки с пользователем {UserId} из чёрного списка") == true).OrderByDescending(x => x.Logged).FirstOrDefault().Logged;
                // Кол-во сообщений с того времени
                return Classes.DBContext.db.BlockedUserMessages.Where(x => x.Time > lastLogged && x.SendlerUserId == UserId).Count();
            } 
        }
        public BlockedUserMessages LastMessage { get
            {
                if (Classes.DBContext.db.BlockedUserMessages.Where(x => x.SendlerUserId == UserId || x.DestinationUserId == UserId).OrderByDescending(x => x.Time).Count() == 0)
                    return new BlockedUserMessages() { Time=DateTime.Parse("2022-02-22 22:22:22") };
                return Classes.DBContext.db.BlockedUserMessages.Where(x => x.SendlerUserId == UserId || x.DestinationUserId == UserId).OrderByDescending(x => x.Time).First();
            } 
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BlockedUserMessages> BlockedUserMessages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BlockedUserMessages> BlockedUserMessages1 { get; set; }
        public virtual Division Division { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Logs> Logs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
        public virtual Permission Permission { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductEnterAct> ProductEnterAct { get; set; }
    }
}
