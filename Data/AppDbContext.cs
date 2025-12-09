using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Compte> Comptes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=gesCompte;Username=postgres;Password=passer");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compte>().ToTable("comptes");
            modelBuilder.Entity<Transaction>().ToTable("transactions");

            modelBuilder.Entity<Compte>()
                .Property(c => c.Type)
                .HasConversion<string>();

            modelBuilder.Entity<Compte>()
                .Property(c => c.Statut)
                .HasConversion<string>();

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Type)
                .HasConversion<string>();
        }

    }
}
