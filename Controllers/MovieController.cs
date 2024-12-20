using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult MovieRemoved()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            var data = _db.Movies.FirstOrDefault(x => x.Id == id);
            _db.Movies.Remove(data);
            _db.SaveChanges();
            return RedirectToAction("MovieRemoved");
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _db.Movies.FirstOrDefault(x => x.Id == id);
            return View(data);
            
        }
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            var data = _db.Movies.FirstOrDefault(x => x.Id == movie.Id);
            if (data != null)
            {
                data.Title = movie.Title;
                data.Director = movie.Director;
                data.ReleaseYear = movie.ReleaseYear;
                data.Price = movie.Price;
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult CopyAMovie(int id)
        {
            _movieService.Copy(id);
            return RedirectToAction("MovieSuccess");
        }

        public IActionResult Details(int id)
        {
            // get the movie by id
            // return movie to the view
            var movie = _movieService.GetMovieById(id);
            return View(movie);
        }

        //public IActionResult Find(Movie movie)
        //{
            
        //    var data1 = _db.Movies.FirstOrDefault(x=>x.Id == id);
        //    var data2= _db.Movies.FirstOrDefault(x => x.Title == Title);
        //    var data3 = _db.Movies.FirstOrDefault(x => x.Director == Director);
        //    var data4 = _db.Movies.FirstOrDefault(x => x.ReleaseYear == ReleaseYear);
        //    return View();
        //}

    }
}
