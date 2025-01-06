using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieShop.Data;

namespace MovieShop.Controllers
{
    public class Admin : Controller
    {
        private readonly MovieDbContext _db;

        public Admin(MovieDbContext movieDbContext)
        {
            _db = movieDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Orders()
        {
            var orders = _db.Orders
                .Include(o => o.OrderRows)
                .ThenInclude(or => or.Movie)
                .Include(o => o.Customer)
                .OrderByDescending(o => o.OrderDate)
                .Select(o => new
                {
                    OrderId = o.Id,
                    CustomerName = $"{o.Customer.FirstNameBillingAddress} {o.Customer.LastNameBillingAddress}",
                    OrderDate = o.OrderDate,
                    TotalCost = o.OrderRows.Sum(or => or.Quantity * or.Price),
                    Movies = o.OrderRows.Select(or => new
                    {
                        or.Movie.Title,
                        or.Quantity,
                        or.Price
                    })
                })
                .ToList();

            return View(orders);
        }
    }
}
