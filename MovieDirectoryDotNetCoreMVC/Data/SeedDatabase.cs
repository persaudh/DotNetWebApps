using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace MovieDirectoryDotNetCoreMVC.Data
{
    public class SeedDatabase
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes the database with seed data.
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="configuration"></param>
        public static void Initialize(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            InitializeGenres(serviceProvider);
            InitializeRatings(serviceProvider);
            InitializeMovies(serviceProvider);
            InitializeMovieGenres(serviceProvider);
            InitializeMoviePosters(serviceProvider);
        }

        /// <summary>
        /// Initializes the genres in the database.
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void InitializeGenres(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MovieDirectoryContext>();

            if (!context.Genres.Any())
            {
                var genresJson = File.ReadAllText("Data/SeedData/Genres.json");
                var genres = JsonSerializer.Deserialize<List<Genre>>(genresJson);

                var now = DateTime.UtcNow;

                foreach (var genre in genres)
                {
                    genre.CreatedDate = now;
                    genre.ModifiedDate = now;
                }

                context.Genres.AddRange(genres);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Initializes the ratings in the database.
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void InitializeRatings(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MovieDirectoryContext>();

            if (!context.Ratings.Any())
            {
                var ratingsJson = File.ReadAllText("Data/SeedData/Ratings.json");
                var ratings = JsonSerializer.Deserialize<List<Rating>>(ratingsJson);

                var now = DateTime.UtcNow;

                foreach (var rating in ratings)
                {
                    rating.CreatedDate = now;
                    rating.ModifiedDate = now;
                }

                context.Ratings.AddRange(ratings);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Initializes the movies in the database.
        /// </summary>  
        /// <param name="serviceProvider"
        public static void InitializeMovies(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MovieDirectoryContext>();

            if (!context.Movies.Any())
            {
                var moviesJson = File.ReadAllText("Data/SeedData/Movies.json");
                var movies = JsonSerializer.Deserialize<List<Movie>>(moviesJson);

                var now = DateTime.UtcNow;
                foreach (var movie in movies)
                {
                    movie.CreatedDate = now;
                    movie.ModifiedDate = now;
                }
                context.Movies.AddRange(movies);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Initializes the MovieGenres in the database.
        /// </summary>  
        /// <param name="serviceProvider"
        public static void InitializeMovieGenres(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MovieDirectoryContext>();

            var movieGenereEntity = context.Model.GetEntityTypes()
                .FirstOrDefault(e => e.Name.Contains("MovieGenre") || e.GetTableName() == "MovieGenres");

            if (movieGenereEntity != null)
            {
                //if(!context.Set<Dictionary<string, object>>(movieGenereEntity.Name).Any())
                //{
                var movieGenresJson = File.ReadAllText("Data/SeedData/MovieGenres.json");
                var movieGeneres = JsonSerializer.Deserialize<List<Dictionary<string, int>>>(movieGenresJson);

                var movieGenresTable = context.Set<Dictionary<string, object>>(movieGenereEntity.Name);

                foreach (var movieGenre in movieGeneres)
                {
                    var exists = movieGenresTable.Any(mg =>
                        mg["MoviesId"].Equals(movieGenre["MoviesId"]) &&
                        mg["GenresId"].Equals(movieGenre["GenresId"]));
                    if (!exists)
                    {
                        // Assuming the JSON contains MoviesId and GenresId
                        movieGenresTable.Add(new Dictionary<string, object>
                        {
                            ["MoviesId"] = movieGenre["MoviesId"],
                            ["GenresId"] = movieGenre["GenresId"]
                        });
                    }
                }
            }
            context.SaveChanges();
            // }

        }

        /// <summary>
        ///     
        public static void InitializeMoviePosters(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MovieDirectoryContext>();
            if (!context.MoviePosters.Any(p => p.CreatedBy == "Initial"))
            {
                var movieJson = File.ReadAllText("Data/SeedData/Movies.json");
                var movieSeeds = JsonSerializer.Deserialize<List<MovieSeedDto>>(movieJson);
                var now = DateTime.UtcNow;

                var moviePosters = new List<MoviePoster>();
                var Id = 1;
                foreach (var movieSeed in movieSeeds)
                {
                    var movie = context.Movies.FirstOrDefault(m => m.Title == movieSeed.Title);
                    if (movie == null)
                        continue;

                    var fileName = Path.GetFileName(movieSeed.ImageUrl);
                    var relativePath = movieSeed.ImageUrl.Contains("wwwroot")
                ? movieSeed.ImageUrl.Substring(movieSeed.ImageUrl.IndexOf("wwwroot") + "wwwroot".Length).Replace("\\", "/")
                : movieSeed.ImageUrl;


                    var poster = new MoviePoster
                    {
                        Id = Id++,
                        FileName = fileName,
                        ContentType = "image/jpeg",
                        LocalPath = relativePath,
                        CreatedBy = movieSeed.CreatedBy,
                        CreatedDate = now,
                        ModifiedBy = movieSeed.ModifiedBy,
                        ModifiedDate = now
                    };

                    context.MoviePosters.Add(poster);
                    context.SaveChanges(); // Get generated ID

                    // Update the Movie's FK
                    movie.MoviePosterId = poster.Id;
                    movie.ModifiedDate = now;

                    context.Movies.Update(movie);
                }
                context.SaveChanges();
            }
        }

        private class MovieSeedDto
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string ReleaseDate { get; set; } // or DateTime if already converted
            public string ImageUrl { get; set; }
            public int RatingId { get; set; }
            public string CreatedBy { get; set; }
            public string ModifiedBy { get; set; }
        }
    }
}
