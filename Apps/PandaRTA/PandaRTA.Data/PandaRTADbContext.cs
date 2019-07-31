using Microsoft.EntityFrameworkCore;
using PandaRTA.Data.Models;
using PandaRTE.Data;

namespace PandaRTA.Data
{
    public class PandaRtaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Receipt> Receipts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSettings.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(x => x.Packages)
                .WithOne(x => x.Recipient)
                .HasForeignKey(x => x.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasMany(x => x.Receipts)
                .WithOne(x => x.Recipient)
                .HasForeignKey(x => x.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<User>().HasMany<Package>()
            //    .WithOne(x => x.Recipient).HasForeignKey(x => x.RecipientId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<User>().HasMany<Receipt>()
            //    .WithOne(x => x.Recipient).HasForeignKey(x => x.RecipientId)
            //    .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }
    }
}