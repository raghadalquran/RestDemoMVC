using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestDemoMVC.Data;
using RestDemoMVC.Models;

namespace RestDemoMVC.Controllers
{
    public class AdminController : Controller
    {
        // Inject
        private readonly ApplicationDbContext _contxt;
        public AdminController(ApplicationDbContext _contxt)
        {
            this._contxt = _contxt;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            // Pass data from controller to view --> ViewBag or ViewData
            ViewBag.total = _contxt.Categories.Count();
            ViewData["totalProducts"] = _contxt.Products.Count();

            // Pass two or more models to single View
            // list products + list categories
            var products = _contxt.Products.ToList();
            var categories = _contxt.Categories.ToList();
            var list = Tuple.Create<IEnumerable<Product>, IEnumerable<Category>>(products, categories);
            return View(list);
        }
    }
}
