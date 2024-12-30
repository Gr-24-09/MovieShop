using MovieShop.Models.DataBase;

namespace MovieShop.Models
{
    public class FrontPageQueriesDisplay
    {
        public List<Movie> Top5Latest { get; set; } = new List<Movie>();
        public List<Movie> Top5Oldest { get; set; } = new List<Movie>();
        public List<Movie> Top5Cheapest { get; set; } = new List<Movie>();
        public List<Movie> AllMovies { get; set; } = new List<Movie>();
        public Movie Movieid { get; set; }
        public Movie Title { get; set; }
        public Movie Director { get; set; }
        public Movie Releaseyear { get; set; }
        public Movie Price { get; set; }

    }
}
