
using MovieShop.Models.DataBase;
using MovieShop.Data;

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

            return new List<Movie>();
        
        }
        public List<Movie> OnDemandMoviesBasedOnOrders()
        {

            return new List<Movie>();
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
        public void Delete(Movie movie)
        {
            _db.Movies.Remove(movie);
            _db.SaveChanges();
        }



    }
}
