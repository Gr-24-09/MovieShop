using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Models;
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
            FrontPageQueriesDisplay obj = new FrontPageQueriesDisplay();
            obj.AllMovies = _movieService.GetAllMovies();
            obj.Top5Latest = _movieService.Top5Newest();
            obj.Top5Cheapest = _movieService.Top5Cheapest();
            obj.Top5Oldest = _movieService.Top5Oldest();
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
