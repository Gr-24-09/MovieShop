using MovieShop.Middleware;
using MovieShop.Models.DataBase;
using MovieShop.Models.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MovieShop.Services
{
    public class CartService : ICartService
    {
        public CartViewModel GetCartMovies(List<Movie> listMovies)
        {
            var cart = new CartViewModel
            {
                ListMovies = listMovies,
                TotalPrice = listMovies.Select(movie => movie.Price).Sum(),
            };
            return cart;
        }
    }
}
