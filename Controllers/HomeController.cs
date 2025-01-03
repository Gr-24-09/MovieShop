using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Middleware;
using MovieShop.Models;
using MovieShop.Models.DataBase;
using MovieShop.Models.ViewModels;
using MovieShop.Services;

namespace MovieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;

        public HomeController(ILogger<HomeController> logger,IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            // Fetch session data and get number of items in the CART, so we can display it next to button in the menu.
            var cartItems = HttpContext.Session.GetObject<List<CartItem>>("CartItems") ?? new List<CartItem>();
            ViewData["CartItemCount"] = cartItems.Select(m => m.Quantity).Sum();

            FrontPageQueriesDisplay obj = new FrontPageQueriesDisplay();
            obj.AllMovies = _movieService.GetAllMovies();
            obj.Top5Latest = _movieService.Top5Newest();
            obj.Top5Cheapest = _movieService.Top5Cheapest();
            obj.Top5Oldest = _movieService.Top5Oldest();
            obj.TopCustomer = _movieService.TopCustomerWhoMadeExpensiveOrder();
            obj.Top20Latest = _movieService.Top20Latest();
            obj.MostPopular = _movieService.OnDemandMoviesBasedOnOrders();
            return View(obj);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
