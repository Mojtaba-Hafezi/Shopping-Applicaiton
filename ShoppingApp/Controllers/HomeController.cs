using Microsoft.AspNetCore.Mvc;

namespace ShoppingApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
