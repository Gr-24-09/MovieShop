using MovieShop.Models.DataBase;

namespace MovieShop.Services
{
    public class CartService : ICartService
    {

        public void AddToCart(ISession session, Movie item)
        {
            throw new NotImplementedException();
        }

        public void ClearCart(ISession session)
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalPrice(ISession session)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromCart(ISession session, int movieId)
        {
            throw new NotImplementedException();
        }

        List<Movie> ICartService.GetCartMovies(ISession session)
        {
            throw new NotImplementedException();
        }
    }
}
