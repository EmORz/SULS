using Microsoft.EntityFrameworkCore;
using Musaca.Data;
using Musaca.Data1.Models;

namespace Musaca.Data1
{
    public class MusacaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
                .HasKey(orderproducts => new {orderproducts.OrderId, orderproducts.ProductId});

            modelBuilder.Entity<Order>()
                .HasMany(x => x.Products)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);

            //modelBuilder.Entity<User>()
            //    .HasKey(user => user.Id);

            //modelBuilder.Entity<Product>()
            //    .HasKey(product => product.Id);

            //modelBuilder.Entity<Order>()
            //    .HasKey(order => order.Id);

            //modelBuilder.Entity<Order>()
            //    .HasMany(order => order.Products)
            //    .WithOne(orderProduct => orderProduct.Order)
            //    .HasForeignKey(orderProduct => orderProduct.OrderId);

            //modelBuilder.Entity<Order>()
            //    .HasOne(order => order.Cashier);

            //modelBuilder.Entity<OrderProduct>()
            //    .HasKey(orderProduct => new {orderProduct.OrderId, orderProduct.ProductId});

            base.OnModelCreating(modelBuilder);
        }
    }
}
