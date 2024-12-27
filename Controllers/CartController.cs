using Microsoft.AspNetCore.Mvc;
using MovieShop.Data;
using MovieShop.Models.DataBase;
using MovieShop.Services;
using MovieShop.Models.ViewModels;
using MovieShop.Middleware;

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
            var cartItems = HttpContext.Session.GetObject<List<Movie>>("CartItems");
            if (cartItems == null)
            {
                return View();
            }
            CartViewModel cart = _cartService.GetCartMovies(cartItems);
            return View(cart);
        }
        public IActionResult AddProductToCart(Movie movie) 
        {
            var cartItems = HttpContext.Session.GetObject<List<Movie>>("CartItems");
            cartItems.Add(movie);
            HttpContext.Session.SetObject<List<Movie>>("CartItems",cartItems); 
            return RedirectToAction(nameof(Index));
        }
        public IActionResult RemoveProductFromCart(Movie movie)
        {
            var cartItems = HttpContext.Session.GetObject<List<Movie>>("CartItems");
            cartItems.Remove(movie);
            HttpContext.Session.SetObject<List<Movie>>("CartItems", cartItems);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EmptyCart()
        {
            HttpContext.Session.Remove("CartItems");
            return RedirectToAction(nameof(Index));
        }
    }
}
