using MovieShop.Models.DataBase;

namespace MovieShop.Models.ViewModels
{
    public class CartViewModel
    {
        public List<Movie> ListMovies { get; set; } = new List<Movie>();
        public decimal TotalPrice {  get; set; } 
    }
}
