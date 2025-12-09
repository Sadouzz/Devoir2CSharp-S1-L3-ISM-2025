using Microsoft.AspNetCore.Mvc;
using Models;
using Data;
using Microsoft.EntityFrameworkCore;
using Services;
using System.Linq;

namespace Controllers
{
    public class CompteController : Controller
    {
        private readonly CompteService _service;
        private const int PageSize = 5;

        public CompteController(AppDbContext db)
        {
            _service = new CompteService(db);
        }

        public IActionResult Index(string search)
        {
            var comptes = _service.SearchComptes(search ?? "");

            ViewBag.Search = search;
            return View(comptes);
        }

        public IActionResult Details(int id, int page = 1, string type = "tous")
        {
            var compte = _service.GetCompteById(id);
            if (compte == null) return NotFound();

            var transactions = compte.Transactions.AsQueryable();

            if (type == "depot")
                transactions = transactions.Where(t => t.Montant > 0);

            if (type == "retrait")
                transactions = transactions.Where(t => t.Montant < 0);

            var transactionsPaged = transactions
                .OrderByDescending(t => t.Date)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)transactions.Count() / PageSize);
            ViewBag.Type = type;

            return View(Tuple.Create(compte, transactionsPaged));
        }
    }
}
