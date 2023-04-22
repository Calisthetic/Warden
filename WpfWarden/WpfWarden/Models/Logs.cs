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

    public partial class Logs
    {
        public int LogId { get; set; }

        private string appName = "WpfWarden";
        public string MachineName { 
            get { return appName; } 
            set { appName = "WpfWarden"; } 
        }
        private Nullable<DateTime> dateTimeNow = null;
        public System.DateTime Logged
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
        public string LogLevel { get; set; }
        [DefaultValue(null)]
        public string Message { get; set; }
        [DefaultValue(null)]
        public string Exception { get; set; }
        public Nullable<int> UserId { get; set; }

        public virtual Users Users { get; set; }
    }
}
