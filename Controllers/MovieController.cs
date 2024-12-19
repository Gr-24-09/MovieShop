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
            return View();
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

        [HttpGet]
        public IActionResult Delete()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieService.Delete(movie);
                return RedirectToAction("MovieRemoved");
            }

            return View();
        }
        public IActionResult MovieRemoved()
        {
            return View();
        }



       
        public IActionResult DeleteMovies(int id)
        {
             _movieService.Delete(id);

            return View();
        }
        

    }
}
