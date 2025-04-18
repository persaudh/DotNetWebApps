using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace MovieDirectory.Services
{
    public class MovieService : IMovieService
    {
        private readonly string _filePath;

        public MovieService(IConfiguration configuration)
        {
            var relativePath = configuration["MovieData:JsonFilePath"];
            _filePath = Path.Combine(AppContext.BaseDirectory, relativePath);
        }

        public async Task<List<Movie>> GetMoviesAsync()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Movie>();
            }

            using (var stream = File.OpenRead(_filePath))
            {
                return await JsonSerializer.DeserializeAsync<List<Movie>>(stream) ?? new List<Movie>();
            }
        }

        public async Task AddMovieAsync(Movie movie)
        {
            var movies = await GetMoviesAsync();
            movie.Id = movies.Count > 0 ? movies.Max(m => m.Id) + 1 : 1;
            movies.Add(movie);

            using var stream = File.Create(_filePath);
            await JsonSerializer.SerializeAsync(stream, movies, new JsonSerializerOptions { WriteIndented = true});
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            var movies = await GetMoviesAsync();
            var index = movies.FindIndex(m => m.Id == movie.Id);

            if (index == -1)
            {
                return false;
            }

            movies[index] = movie;

            using var stream = File.Create(_filePath);
            await JsonSerializer.SerializeAsync(stream, movies, new JsonSerializerOptions { WriteIndented = true });

            return true;
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movies = await GetMoviesAsync();
            var movieToDelete = movies.First(m => m.Id == id);
            if (movieToDelete == null)
            {
                return false;
            }
            movies.Remove(movieToDelete);
            using var stream = File.Create(_filePath);
            await JsonSerializer.SerializeAsync(stream, movies, new JsonSerializerOptions { WriteIndented = true });
            return true;
        }

        public async Task<List<Movie>> RestMovieAsync()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Movie>();
            }

            using (var stream = File.OpenRead(_filePath))
            {
                return await JsonSerializer.DeserializeAsync<List<Movie>>(stream) ?? new List<Movie>();
            }

        }
    }

    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public List<string> Genres { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public double Rating { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
