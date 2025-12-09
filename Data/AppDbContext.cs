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

            modelBuilder.Entity<Compte>().HasData(
                new Compte
                {
                    Id = 8,
                    Numero = "SN001",
                    Titulaire = "Ousman Sadjo",
                    Type = TypeCompte.Epargne,
                    Solde = 510500,
                    DateCreation = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    Statut = StatutCompte.Actif
                },
                new Compte
                {
                    Id = 9,
                    Numero = "SN002",
                    Titulaire = "Layla Sadjo",
                    Type = TypeCompte.Courant,
                    Solde = 50500,
                    DateCreation = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    Statut = StatutCompte.Actif
                }
            );

            modelBuilder.Entity<Transaction>().HasData(
                new Transaction { Id = 1, CompteId = 1, Code = "TRX001", Montant = 150000, SoldeApres = 150000, Type = TransactionType.Depot, Description = "Dépôt cash au guichet", Date = new DateTime(2025, 1, 3, 0, 0, 0, DateTimeKind.Utc) },
                new Transaction { Id = 2, CompteId = 1, Code = "TRX002", Montant = 50000, SoldeApres = 200000, Type = TransactionType.Depot, Description = "Dépôt cash", Date = new DateTime(2025, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                new Transaction { Id = 3, CompteId = 1, Code = "TRX003", Montant = 120000, SoldeApres = 320000, Type = TransactionType.Depot, Description = "Salaire mensuel", Date = new DateTime(2025, 1, 17, 0, 0, 0, DateTimeKind.Utc) },
                new Transaction { Id = 4, CompteId = 1, Code = "TRX004", Montant = -20000, SoldeApres = 300000, Type = TransactionType.Retrait, Description = "Retrait ATM Dakar Plateau", Date = new DateTime(2025, 1, 20, 0, 0, 0, DateTimeKind.Utc) },
                new Transaction { Id = 5, CompteId = 1, Code = "TRX005", Montant = -15000, SoldeApres = 285000, Type = TransactionType.Retrait, Description = "Achat Orange Money", Date = new DateTime(2025, 1, 22, 0, 0, 0, DateTimeKind.Utc) },
                new Transaction { Id = 6, CompteId = 1, Code = "TRX006", Montant = 30000, SoldeApres = 315000, Type = TransactionType.Depot, Description = "Dépôt wave", Date = new DateTime(2025, 1, 25, 0, 0, 0, DateTimeKind.Utc) },
                new Transaction { Id = 7, CompteId = 1, Code = "TRX007", Montant = 80000, SoldeApres = 395000, Type = TransactionType.Depot, Description = "Paiement Freelance", Date = new DateTime(2025, 1, 28, 0, 0, 0, DateTimeKind.Utc) },
                new Transaction { Id = 8, CompteId = 1, Code = "TRX008", Montant = -25000, SoldeApres = 370000, Type = TransactionType.Retrait, Description = "Achat nourriture Auchan", Date = new DateTime(2025, 1, 30, 0, 0, 0, DateTimeKind.Utc) },
                new Transaction { Id = 9, CompteId = 1, Code = "TRX009", Montant = -5000, SoldeApres = 365000, Type = TransactionType.Retrait, Description = "Café Matin", Date = new DateTime(2025, 2, 2, 0, 0, 0, DateTimeKind.Utc) },
                new Transaction { Id = 10, CompteId = 1, Code = "TRX010", Montant = -10000, SoldeApres = 355000, Type = TransactionType.Retrait, Description = "Transport Dem Dikk", Date = new DateTime(2025, 2, 5, 0, 0, 0, DateTimeKind.Utc) }
            );
        }
    }
}
