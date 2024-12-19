using Microsoft.AspNetCore.Mvc;

namespace MovieShop.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
