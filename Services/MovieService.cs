
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
        public Movie GetMovieById(int id)
        {
            var movie = _db.Movies.FirstOrDefault(x => x.Id == id);
            return movie;
        }
        public Movie GetMovieByTitle(string title)
        {
            var movie = _db.Movies.FirstOrDefault(x => x.Title == title);
            return movie;
        }
        public Movie GetMovieByDirector(string director)
        {
            var movie = _db.Movies.FirstOrDefault(x => x.Director == director);
            return movie;
        }
        public Movie GetMovieByReleaseYear(int releaseyear)
        {
            var movie = _db.Movies.FirstOrDefault(x => x.ReleaseYear == releaseyear);
            return movie;
        }

        public void Copy(int id)
        {
            var data = _db.Movies.FirstOrDefault(x=>x.Id==id);
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
