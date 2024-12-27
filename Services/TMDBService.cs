using MovieShop.Data;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using MovieShop.Models.DataBase;

namespace MovieShop.Services
{
    public class TMDBService
    {
        private readonly IConfiguration _configuration;
        private readonly MovieDbContext _dbContext;
        private readonly string _apiKey;

        public TMDBService(IConfiguration configuration, MovieDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
            _apiKey = _configuration["TMDB:ApiKey"];
        }

        public async Task UpdatePosterPathsAsync()
        {
            var httpClient = new HttpClient();
            var movies = await _dbContext.Movies.ToListAsync();

            foreach (var movie in movies)
            {
                try
                {
                    var posterUrl = await GetPosterUrlAsync(httpClient, movie.Title, movie.ReleaseYear);
                    if (posterUrl != null)
                    {
                        movie.PosterPath = posterUrl;
                        _dbContext.Movies.Update(movie);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading a movie {movie.Title}: {ex.Message}");
                }
            }

            await _dbContext.SaveChangesAsync();
            Console.WriteLine("Poster paths updated successfully");
        }

        private async Task<string?> GetPosterUrlAsync(HttpClient httpClient, string title, int releaseYear)
        {
            var query = $"https://api.themoviedb.org/3/search/movie?api_key={_apiKey}&query={Uri.EscapeDataString(title)}&year={releaseYear}";
            var response = await httpClient.GetStringAsync(query);
            var json = JObject.Parse(response);
            var results = json["results"] as JArray;

            if (results == null || !results.Any())
                return null;

            var posterPath = results.First["poster_path"]?.ToString();
            return posterPath != null ? $"https://image.tmdb.org/t/p/w500{posterPath}" : null;
        }
    }
}





