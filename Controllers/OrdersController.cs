using Microsoft.AspNetCore.Mvc;
using MovieShop.Data;

namespace MovieShop.Controllers
{
    public class OrdersController : Controller
    {
        private readonly MovieDbContext _dbContext;

        public OrdersController(MovieDbContext dbContext)
        {

            _dbContext = dbContext;
        }

        public IActionResult AllOrders()
        {
            var allOrders=_dbContext.Orders.ToList();

            return View(allOrders);
        }

        public IActionResult LatestOrder()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
