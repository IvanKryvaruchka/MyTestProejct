using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly NorthwindContext _context;

        public ProductsController(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
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

            return Json(products);
        }
    }
}
