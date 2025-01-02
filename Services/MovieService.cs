
using MovieShop.Models.DataBase;
using MovieShop.Data;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MovieShop.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _db;
        public MovieService(MovieDbContext db)
        {
            _db = db;

        }
        public void Create(Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
        }
        public List<Movie> GetAllMovies()
        {
            var resultAll = _db.Movies.ToList();
            return resultAll;
        }
        public List<Movie> TopCustomerWhoMadeExpensiveOrder()
        {
            //var result = _db.OrderRows.OrderBy (f => f.Price).Take(1);

            return new List<Movie>();

        }
        public List<Movie> OnDemandMoviesBasedOnOrders()
        {

            return new List<Movie>();
        }
        public List<Movie> Top20Latest()
        {
            var results = _db.Movies.OrderByDescending(x => x.ReleaseYear).Take(20).ToList();

            return results;
        }
        public List<Movie> Top5Newest()
        {
            var resultNew = _db.Movies.OrderByDescending(x => x.ReleaseYear).Take(5).ToList();

            return resultNew;
        }
        public List<Movie> Top5Cheapest()
        {
            var resultCheap = _db.Movies.OrderBy(x => x.Price).Take(5).ToList();

            return resultCheap;

        }
        public List<Movie> Top5Oldest()
        {
            var resultOld = _db.Movies.OrderBy(x => x.ReleaseYear).Take(5).ToList();

            return resultOld;

        }
        public Movie GetMovieById(int id)
        {
            var movieS = _db.Movies.FirstOrDefault(x => x.Id == id);
            return movieS;
        }
       
        public void Copy(int id)
        {
            var data = _db.Movies.FirstOrDefault(x => x.Id == id);
            var movie = new Movie()
            {
                Title = data.Title,
                Director = data.Director,
                ReleaseYear = data.ReleaseYear,
                Price = data.Price
            };
            _db.Movies.Add(movie);
            _db.SaveChanges();
        }
    }
}
            
            
            

       
