using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MovieShop.Data;
using MovieShop.Models;
using MovieShop.Models.DataBase;
using MovieShop.Services;
using System.Reflection.Metadata;

namespace MovieShop.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly MovieDbContext _db;

        public MovieController(IMovieService movieService, MovieDbContext db)
        {
            _movieService = movieService;
            _db = db;
        }
        public IActionResult Index()
        {
            return View( _movieService.GetAllMovies() );
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieService.Create(movie);
                return RedirectToAction("MovieSuccess");
            }

            return View();
        }

        public IActionResult MovieSuccess()
        {
            return View();
        }
       
        public IActionResult Top5NewestMovies()
        {

            return View(_movieService.Top5Newest());
        }
        public IActionResult Top5OldestMovies()
        {

            return View(_movieService.Top5Oldest());
        }
        public IActionResult Top5CheapestMovies()
        {

            return View(_movieService.Top5Cheapest());
        }

        public IActionResult AllMovies()
        {

            return View(_movieService.GetAllMovies());
        }
    }
}
