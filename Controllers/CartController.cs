using Microsoft.AspNetCore.Mvc;
using MovieShop.Data;
using MovieShop.Middleware;
using MovieShop.Models.DataBase;
using MovieShop.Models.ViewModels;
using MovieShop.Services;
using Newtonsoft.Json;

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

        //     You can use this code to add button "ADD TO CART" for Movies.
        //     <form asp-controller="Cart" asp-action="AddProductToCart" method="post">
        //     <input type = "hidden" name="Id" value="@item.Id" />
        //     <button class="btn-block btn-dark" type="submit">Add to cart</button>
        //     </form>

        public IActionResult Index()
        {
            var cartItems = HttpContext.Session.GetObject<List<CartItem>>("CartItems");
            if (cartItems == null)
            {
                _logger.LogInformation("Loading Cart/Index view.");
                return View();
            }
            CartViewModel cart = _cartService.GetCartMovies(cartItems);

            return View(cart);
        }
        public IActionResult AddProductToCart(int id)
        {
            var movie = _db.Movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                var cartItems = HttpContext.Session.GetObject<List<CartItem>>("CartItems");
                _cartService.AddToCart(cartItems, movie);
                HttpContext.Session.SetObject<List<CartItem>>("CartItems", cartItems);
            }

            // (In case of using outside of Cart Index View)
            // Get the referrer URL from the request headers 
            var refererUrl = Request.Headers["Referer"].ToString();
            if (!string.IsNullOrEmpty(refererUrl))
            {
                return Redirect(refererUrl);  // Redirect back to the page the user was on
            }

            // If referer is not available, fallback to a default page (Home Index)
            return RedirectToAction("Index", "Home");
        }
        public IActionResult RemoveProductFromCart(int id)
        {
            var movie = _db.Movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                var cartItems = HttpContext.Session.GetObject<List<CartItem>>("CartItems");
                _cartService.RemoveFromCart(cartItems, id);
                HttpContext.Session.SetObject<List<CartItem>>("CartItems", cartItems);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult LowerQuantity(int id)
        {
            var movie = _db.Movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                var cartItems = HttpContext.Session.GetObject<List<CartItem>>("CartItems");
                _cartService.LowerQuantity(cartItems, id);
                HttpContext.Session.SetObject<List<CartItem>>("CartItems", cartItems);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult EmptyCart()
        {
            HttpContext.Session.Remove("CartItems");
            return View();
        }
        public IActionResult ShowSession()
        {
            var cartItems = HttpContext.Session.GetObject<List<Movie>>("CartItems") ?? new List<Movie>();
            return Content(JsonConvert.SerializeObject(cartItems));
        }
    }
}
