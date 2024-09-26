using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebAPI.Data;

namespace WebAPI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly NorthwindContext _context;

        public CategoriesController(NorthwindContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }
    }
}
