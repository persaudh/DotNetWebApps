using System.Text.Json;

namespace MovieDirectoryDotNetCoreMVC.Data
{
    public class SeedDatabase
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;
        public static void Initialize(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            InitilizeGenres(serviceProvider);
            InitializeRatings(serviceProvider);
            InitializeMovies(serviceProvider);
            InitializeMovieGenres(serviceProvider);
        }

        public static void InitilizeGenres(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MovieDirectoryContext>();

            if (!context.Genres.Any())
            {
                var genresJson = File.ReadAllText("Data/SeedData/Genres.json");
                var genres = JsonSerializer.Deserialize<List<Genre>>(genresJson);

                var now = DateTime.Now;

                foreach (var genre in genres)
                {
                    genre.CreatedDate = now;
                    genre.ModifiedDate = now;
                }

                context.Genres.AddRange(genres);
                context.SaveChanges();
            }
        }
        public static void InitializeRatings(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MovieDirectoryContext>();

            if (!context.Ratings.Any())
            {
                var ratingsJson = File.ReadAllText("Data/SeedData/Ratings.json");
                var ratings = JsonSerializer.Deserialize<List<Rating>>(ratingsJson);

                var now = DateTime.Now;

                foreach (var rating in ratings)
                {
                    rating.CreatedDate = now;
                    rating.ModifiedDate = now;
                }

                context.Ratings.AddRange(ratings);
                context.SaveChanges();
            }
        }

        public static void InitializeMovies(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MovieDirectoryContext>();

            if (!context.Movies.Any())
            {
                var moviesJson = File.ReadAllText("Data/SeedData/Movies.json");
                var movies = JsonSerializer.Deserialize<List<Movie>>(moviesJson);

                var now = DateTime.Now;
                foreach (var movie in movies)
                {
                    movie.CreatedDate = now;
                    movie.ModifiedDate = now;
                }
                context.Movies.AddRange(movies);
                context.SaveChanges();
            }
        }

        public static void InitializeMovieGenres(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MovieDirectoryContext>();

            var movieGenereEntity = context.Model.FindEntityType("MovieGeners");
            if (movieGenereEntity != null)
            {
                var movieGenresJson = File.ReadAllText("Data/SeedData/MovieGenres.json");
                var movieGeneres = JsonSerializer.Deserialize<List<Dictionary<string, int>>>(movieGenresJson);

                var movieGenresTable = context.Set<Dictionary<string, object>>(movieGenereEntity.Name);

                foreach (var movieGenre in movieGeneres)
                {
                    movieGenresTable.Add(new Dictionary<string, object>
                    {
                        ["MovieId"] = movieGenre["MovieId"],
                        ["GenreId"] = movieGenre["GenreId"]
                    });
                }
            }
        }
    }
}
