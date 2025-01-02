using MovieShop.Models.DataBase;
using MovieShop.Models.ViewModels;


namespace MovieShop.Services
{
    public interface ICartService
    {
        public CartViewModel GetCartMovies(List<CartItem> cartItems);
        public void AddToCart(List<CartItem> cartItems, Movie movie);
        public void RemoveFromCart(List<CartItem> cartItems, int movieId);
        public void LowerQuantity(List<CartItem> cartItems, int movieId);
    }
}
