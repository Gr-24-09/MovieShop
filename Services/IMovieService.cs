using MovieShop.Models.DataBase;

namespace MovieShop.Services
{
    public interface IMovieService
    {
        public List<Movie> GetAllMovies();
        public List<Movie> OnDemandMoviesBasedOnOrders();
        public List<Movie> Top5Oldest();
        public List<Movie> Top5Newest(); 
        public List<Movie> Top5Cheapest();
        public List<Movie> TopCustomerWhoMadeExpensiveOrder();
        public void Create(Movie movie);

        public void Delete(Movie movie);
        public void Delete(int id);


    }
}
