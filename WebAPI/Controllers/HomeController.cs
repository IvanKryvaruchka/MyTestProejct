using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Welcome to the Northwind Database Web Application!";
            return View();
        }
    }
}
