using MovieShop.Models.DataBase;

namespace MovieShop.Services
{
    public interface IMovieService
    {
        public List<Movie> GetAllMovies();
        public List<Movie> OnDemandMoviesBasedOnOrders();
        public List<Movie> TopCustomerWhoMadeExpensiveOrder();
        public List<Movie> Top5Oldest();
        public List<Movie> Top5Newest(); 
        public List<Movie> Top5Cheapest();
        public Movie GetMovieById(int id);
        public Movie GetMovieByTitle(string title);
        public Movie GetMovieByDirector(string director);
        public Movie GetMovieByReleaseYear(int ryear);
        public void Create(Movie movie);
        public void Copy(int id);
       

    }
}
