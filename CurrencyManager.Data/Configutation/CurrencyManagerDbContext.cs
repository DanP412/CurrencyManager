using CurrencyManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace CurrencyManager.Data.Configutation
{
    public class CurrencyManagerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CurrencyManager;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("Users");
                entityTypeBuilder.HasKey(u => u.Id);
                entityTypeBuilder.Property(u => u.Password);
                entityTypeBuilder.Property(u => u.Email);
                entityTypeBuilder.Property(u => u.Balance);
            });

        }
    }
}
