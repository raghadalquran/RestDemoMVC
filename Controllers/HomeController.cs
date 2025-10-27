using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestDemoMVC.Data;
using RestDemoMVC.Models;
using SQLitePCL;
using System.Diagnostics;
using System.Security.Claims;

namespace RestDemoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // Inject
        private readonly ApplicationDbContext _contxt;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext _contxt)
        {
            _logger = logger;
            this._contxt = _contxt;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Menu()
        {
            var categories = _contxt.Categories.Include(c => c.products).ToList();
            return View(categories);   
        }
        public async Task<IActionResult> SearchProducts(string name)
        {
            // Get categories that have products matching the search
            var categories = await _contxt.Categories
                .Include(c => c.products)
                .Where(c => c.products.Any(p => p.Name.Contains(name)))
                .ToListAsync();

           // return View("Menu", categories);
        }
    }
}
