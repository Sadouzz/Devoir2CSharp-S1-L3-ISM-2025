using System.Linq;
using Models;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class CompteService
    {
        private readonly AppDbContext appDbContext;

        public CompteService(AppDbContext db)
        {
            appDbContext = db;
        }

        public Compte GetCompteById(int id)
        {
            return appDbContext.Comptes
                      .Include(c => c.Transactions)
                      .FirstOrDefault(c => c.Id == id);
        }

        public Compte GetCompteByNumero(string numero)
        {
            return appDbContext.Comptes
                      .Include(c => c.Transactions)
                      .FirstOrDefault(c => c.Numero == numero);
        }

        public List<Compte> SearchComptes(string recherche)
        {
            return appDbContext.Comptes
                      .Where(c => c.Numero.Contains(recherche) || c.Titulaire.Contains(recherche))
                      .Include(c => c.Transactions)
                      .ToList();
        }
    }
}
