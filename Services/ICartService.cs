using MovieShop.Models.DataBase;
using MovieShop.Models.ViewModels;


namespace MovieShop.Services
{
    public interface ICartService
    {
        public CartViewModel GetCartMovies(List<Movie> listMovies); 
    }
}
