using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly NorthwindContext _context;
        private readonly IConfiguration _configuration;

        public ProductsController(NorthwindContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var maxProductsToShow = _configuration.GetValue<int>("MaxProductsToShow");

            var products = await _context.Products
                .Select(p => new Product
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    CategoryId = p.CategoryId,
                    CategoryName = _context.Categories.FirstOrDefault(c => c.CategoryId == p.CategoryId).CategoryName,
                    SupplierId = p.SupplierId,
                    SupplierName = _context.Suppliers.FirstOrDefault(s => s.SupplierId == p.SupplierId).CompanyName,
                    QuantityPerUnit = p.QuantityPerUnit,
                    UnitPrice = p.UnitPrice,
                    UnitsInStock = p.UnitsInStock,
                    UnitsOnOrder = p.UnitsOnOrder,
                    ReorderLevel = p.ReorderLevel,
                    Discontinued = p.Discontinued
                })
                .ToListAsync();

            if (maxProductsToShow > 0)
            {
                products = products.Take(maxProductsToShow).ToList();
            }

            return View(products);
        }
    }
}
