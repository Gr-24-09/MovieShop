using MovieShop.Models.DataBase;

namespace MovieShop.Services
{
    public interface ICartService
    {
        // SEPARATE ACTIONS - ADD / REMOVE / CLEAN CART - USER INTERFACE LOGIC.
        void AddToCart(ISession session, Movie item); 
        void RemoveFromCart(ISession session, int movieId);
        void ClearCart(ISession session); 

        // PART OF INDEX - CART VIEW inside INDEX ACTION.
        decimal GetTotalPrice(ISession session); 
        List<Movie> GetCartMovies(ISession session); 
    }
}
