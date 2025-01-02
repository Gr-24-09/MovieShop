using MovieShop.Middleware;
using MovieShop.Models.DataBase;
using MovieShop.Models.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MovieShop.Services
{
    public class CartService : ICartService
    {
        public CartViewModel GetCartMovies(List<CartItem> cartItems)
        {
            var cartViewModel = new CartViewModel
            {
                CartItem = cartItems,
                SubTotalPrice = cartItems.Sum(item => item.Movie.Price * item.Quantity)
            };
            return cartViewModel;
        }

        public void AddToCart(List<CartItem> cartItems, Movie movie)
        {
            var cartItem = cartItems.FirstOrDefault(item => item.Movie.Id == movie.Id);
            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                cartItems.Add(new CartItem
                {
                    Movie = movie,
                    Quantity = 1
                });
            }
        }

        public void RemoveFromCart(List<CartItem> cartItems, int movieId)
        {
            var cartItem = cartItems.FirstOrDefault(item => item.Movie.Id == movieId);
            if (cartItem != null)
            {
                    cartItems.Remove(cartItem);
            }
        }


        public void LowerQuantity(List<CartItem> cartItems, int movieId)
        {
            var cartItem = cartItems.FirstOrDefault(item => item.Movie.Id == movieId);
            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                }
                else
                {
                    cartItems.Remove(cartItem);
                }
            }
        }
    }
}
