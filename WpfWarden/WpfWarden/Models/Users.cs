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
    using System.ComponentModel.DataAnnotations;

    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.Order = new HashSet<Order>();
            this.ProductEnterAct = new HashSet<ProductEnterAct>();
            this.UserEnterStory = new HashSet<UserEnterStory>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        [Required]
        [DefaultValue(null)]
        string tempThirdName = string.Empty;
        public string ThirdName
        {
            set { tempThirdName = value; }
            get { return tempThirdName; }
        }
        [Required]
        [DefaultValue(null)]
        string tempLogin = string.Empty;
        public string Login
        {
            set { tempLogin = value; }
            get { return tempLogin; }
        }
        [Required]
        [DefaultValue(null)]
        string tempPassword = string.Empty;
        public string Password
        {
            set { tempPassword = value; }
            get { return tempPassword; }
        }
        [Required]
        [DefaultValue(null)]
        string tempSecretWord = string.Empty;
        public string SecretWord
        {
            set { tempSecretWord = value; }
            get { return tempSecretWord; }
        }
        public int DivisionId { get; set; }
        public Nullable<int> PermissionId { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool IsBlocked { get; set; }
        public bool Gender { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool IsVerify { get; set; }

        public virtual Division Division { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
        public virtual Permission Permission { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductEnterAct> ProductEnterAct { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserEnterStory> UserEnterStory { get; set; }





    }
}
