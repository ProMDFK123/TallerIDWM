using api.src.Models;
using Microsoft.EntityFrameworkCore;

namespace api.src.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address1> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Address1)
                .WithOne(a => a.User)
                .HasForeignKey<Address1>(a => a.UserId)
                .IsRequired(false);
        }
    }
}