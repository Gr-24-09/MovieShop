using Microsoft.AspNetCore.Mvc;
using MovieShop.Data;
using MovieShop.Models.DataBase;
using MovieShop.Services;

namespace MovieShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService; 
        private readonly MovieDbContext _db;
        private readonly ILogger<CartController> _logger;
        public CartController(ICartService cartService, MovieDbContext db, ILogger<CartController> logger)
        {
            _cartService = cartService;
            _db = db;
            _logger = logger;
        }
     
        public IActionResult Index()
        {
            //var cartItems = _cartService.GetCartMovies(HttpContext.Session); // TODO : Add Session logic for cart.
            //var totalPrice = _cartService.GetTotalPrice(HttpContext.Session);

            //var model = new CartViewModel // TODO : Create View Model for CartViewModel
            //{
            //    Items = cartItems,
            //    TotalPrice = totalPrice
            //};

            return View(); // TODO: return View(model) after fixes.
        }
        public IActionResult AddProductToCart(ISession session, Movie item) 
        {
 
            return RedirectToAction(nameof(Index));
        }
        public IActionResult RemoveProductFromCart(ISession session, Movie item)
        {
       
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EmptyCart(ISession session)
        {

            return RedirectToAction(nameof(Index));
        }
    }
}
