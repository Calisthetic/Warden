using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiCoreWarden.Models;

public partial class WardenContext : DbContext
{
    public WardenContext()
    {
    }

    public WardenContext(DbContextOptions<WardenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BlockedUserMessage> BlockedUserMessages { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductEnterAct> ProductEnterActs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-GJJERNN;Database=Warden;Trusted_Connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BlockedUserMessage>(entity =>
        {
            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.DestinationUser).WithMany(p => p.BlockedUserMessageDestinationUsers)
                .HasForeignKey(d => d.DestinationUserId)
                .HasConstraintName("FK_BlockedUserMessages_Users1");

            entity.HasOne(d => d.SendlerUser).WithMany(p => p.BlockedUserMessageSendlerUsers)
                .HasForeignKey(d => d.SendlerUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BlockedUserMessages_Users");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.ToTable("Division");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.Property(e => e.LogLevel).HasMaxLength(50);
            entity.Property(e => e.Logged).HasColumnType("datetime");
            entity.Property(e => e.MachineName).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.Logs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Logs_Users");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.DeliverCompany).HasMaxLength(100);
            entity.Property(e => e.DeliveredDate).HasColumnType("date");
            entity.Property(e => e.TrackCode).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Users");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.PermissionId).HasName("PK_Role");

            entity.ToTable("Permission");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_ProductCategory");

            entity.HasOne(d => d.Order).WithMany(p => p.Products)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Order");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.ToTable("ProductCategory");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<ProductEnterAct>(entity =>
        {
            entity.ToTable("ProductEnterAct");

            entity.Property(e => e.CreateDate).HasColumnType("date");
            entity.Property(e => e.EnterDate).HasColumnType("date");

            entity.HasOne(d => d.Order).WithMany(p => p.ProductEnterActs)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductEnterAct_Order");

            entity.HasOne(d => d.User).WithMany(p => p.ProductEnterActs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductEnterAct_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.Login).HasMaxLength(30);
            entity.Property(e => e.Password).HasMaxLength(30);
            entity.Property(e => e.SecondName).HasMaxLength(30);
            entity.Property(e => e.SecretWord).HasMaxLength(30);
            entity.Property(e => e.ThirdName).HasMaxLength(30);

            entity.HasOne(d => d.Division).WithMany(p => p.Users)
                .HasForeignKey(d => d.DivisionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Division");

            entity.HasOne(d => d.Permission).WithMany(p => p.Users)
                .HasForeignKey(d => d.PermissionId)
                .HasConstraintName("FK_Users_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
