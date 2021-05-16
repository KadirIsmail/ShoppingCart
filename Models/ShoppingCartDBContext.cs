using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ShoppingCart.Models
{
    public partial class ShoppingCartDBContext : DbContext
    {
        public ShoppingCartDBContext()
        {
        }

        public ShoppingCartDBContext(DbContextOptions<ShoppingCartDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoryTbl> CategoryTbls { get; set; }
        public virtual DbSet<CustomerTbl> CustomerTbls { get; set; }
        public virtual DbSet<ProductTbl> ProductTbls { get; set; }
        public virtual DbSet<ShoppingCartTbl> ShoppingCartTbls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS01;Database=ShoppingCartDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<CategoryTbl>(entity =>
            {
                entity.ToTable("CategoryTbl");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerTbl>(entity =>
            {
                entity.ToTable("CustomerTbl");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CustName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaxNo)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductTbl>(entity =>
            {
                entity.ToTable("ProductTbl");

                entity.Property(e => e.Photo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CategoryId).HasColumnType("int");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ShoppingCartTbl>(entity =>
            {
                entity.ToTable("ShoppingCartTbl");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(21, 2)")
                    .HasComputedColumnSql("([Price]*[Quantity])", false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
