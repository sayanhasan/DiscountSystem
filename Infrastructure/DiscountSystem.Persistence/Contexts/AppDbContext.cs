using DiscountSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountSystem.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Discount> Discounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ProductsBuilder
            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(20,5)");
            modelBuilder.Entity<Product>().Property(x => x.Name).HasColumnType("varchar(500)");
            //one to many rs
            modelBuilder.Entity<Product>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
            #region CompanyBuilder
            modelBuilder.Entity<Category>().HasKey(x => x.Id);
            modelBuilder.Entity<Category>().Property(x => x.Name).HasColumnType("varchar(500)");
            modelBuilder.Entity<Category>()
               .HasOne(x => x.Discount)
               .WithMany(x => x.Categories)
               .HasForeignKey(x => x.DiscountId)
               .OnDelete(DeleteBehavior.NoAction);
            #endregion
            #region DiscountBuilder
            modelBuilder.Entity<Discount>().HasKey(x => x.Id);
            modelBuilder.Entity<Discount>().Property(x => x.Name).HasColumnType("varchar(500)");
            modelBuilder.Entity<Discount>().Property(x => x.StartDate).HasColumnType("varchar(500)");
            modelBuilder.Entity<Discount>().Property(x => x.EndDate).HasColumnType("varchar(500)");
            modelBuilder.Entity<Discount>().Property(x => x.Rate).HasColumnType("decimal(20,5)");
            #endregion
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        }

    }
}
