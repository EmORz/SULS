using FDMC.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FDMC.Data
{
    public class FdmcDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Kitten> Kittens { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<OrderProduct>()
            //    .HasKey(orderproducts => new {orderproducts.OrderId, orderproducts.ProductId});

            //modelBuilder.Entity<Order>()
            //    .HasMany(x => x.Products)
            //    .WithOne(x => x.Order)
            //    .HasForeignKey(x => x.OrderId);

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
