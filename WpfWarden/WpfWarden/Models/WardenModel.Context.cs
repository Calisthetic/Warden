﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WardenEntities : DbContext
    {
        public WardenEntities()
            : base("name=WardenEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductEnterAct> ProductEnterAct { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
