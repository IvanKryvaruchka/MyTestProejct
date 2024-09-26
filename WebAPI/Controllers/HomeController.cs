using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var message = new { Message = "Welcome to the Northwind Database Web Application!" };
            return Json(message);
        }
    }
}
