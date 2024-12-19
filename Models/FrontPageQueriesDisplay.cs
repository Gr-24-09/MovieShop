using MovieShop.Models.DataBase;

namespace MovieShop.Models
{
    public class FrontPageQueriesDisplay
    {
        public List<Movie> Top5Latest { get; set; } = new List<Movie>();

        public List<Movie> Top5Oldest { get; set; } = new List<Movie>();
        public List<Movie> Top5Cheapest { get; set; } = new List<Movie>();
        public List<Movie> AllMovies { get; set; } = new List<Movie>();

    }
}
