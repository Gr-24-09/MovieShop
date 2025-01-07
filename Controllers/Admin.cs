using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieShop.Data;
using MovieShop.Models.ViewModels;

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
                .Select(o => new OrderViewModel
                {
                    OrderId = o.Id,
                    CustomerName = $"{o.Customer.FirstNameBillingAddress} {o.Customer.LastNameBillingAddress}",
                    OrderDate = o.OrderDate,
                    Totalcost = o.OrderRows.Sum(or => or.Quantity * or.Price),
                    Movies = o.OrderRows.Select(or => new MovieItemViewModel
                    {
                        Title = or.Movie.Title,
                        Quantity = or.Quantity,
                        Price = or.Price
                    }).ToList()
                })
                .ToList();

            return View(orders);
        }
    }
}
