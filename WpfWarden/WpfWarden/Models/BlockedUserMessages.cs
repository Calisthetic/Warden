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
    using System.Diagnostics;
    using System.Linq;
    using System.Windows;

    public partial class BlockedUserMessages
    {
        public int BlockedUserMessageId { get; set; }
        public int SendlerUserId { get; set; }
        [DefaultValue(null)]
        public Nullable<int> DestinationUserId { get; set; }
        public string Message { get; set; }
        private Nullable<DateTime> dateTimeNow = null;
        public System.DateTime Time
        {
            get
            {
                return this.dateTimeNow.HasValue
                    ? this.dateTimeNow.Value
                    : DateTime.Now;
            }
            set
            {
                this.dateTimeNow = value;
            }
        }
        public int UncheckedMessagesCount
        {
            get
            {
                // Последнее время входа сотрудника ИБ
                DateTime lastLogged = Classes.DBContext.db.Logs.Where(x => x.Users.Permission.Name == "Специалист по ИБ").OrderByDescending(x => x.Logged).Skip(1).FirstOrDefault().Logged;
                Debug.Write(lastLogged);
                // Кол-во сообщений с того времени
                return Classes.DBContext.db.BlockedUserMessages.Where(x => x.Time > lastLogged && x.SendlerUserId == x.Users.UserId).Count();
            }
        }

        public virtual Users Users { get; set; }
        public virtual Users Users1 { get; set; }
    }
}
