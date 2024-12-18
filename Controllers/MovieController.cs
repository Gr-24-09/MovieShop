using Microsoft.AspNetCore.Mvc;

namespace MovieShop.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
