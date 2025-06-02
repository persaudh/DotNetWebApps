using MovieDirectoryDotNetCoreMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace MovieDirectoryDotNetCoreMVC.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieDirectoryContext _context;
        public MovieService(MovieDirectoryContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies
                .Include(m => m.Genres)
                .Include(m => m.Rating)
                .Include(m => m.MoviePoster)
                .ToListAsync();
        }

        public async Task<List<Movie>> GetMoviesByGenreAsync(List<int> genreIDs)
        {
            var movieQuery = _context.Movies
                .Include(m => m.Genres)
                .Include(m => m.Rating)
                .Include(m => m.MoviePoster)
                .AsQueryable();

            if (genreIDs != null && genreIDs.Any())
            {
                movieQuery = movieQuery.Where(m =>
                   genreIDs.All(gid => m.Genres.Select(g => g.Id).Contains(gid))
                 );

            }

            return await movieQuery.ToListAsync();
        }

        public async Task<List<Movie>> GetMoviesByRatingAsync(List<int> ratingIDs)
        {
            var movieQuery = _context.Movies
                .Include(m => m.Genres)
                .Include(m => m.Rating)
                .Include(m => m.MoviePoster)
                .AsQueryable();
            if (ratingIDs != null && ratingIDs.Any())
            {
                movieQuery = movieQuery.Where(m =>
                    ratingIDs.Contains(m.RatingId)
                );
            }
            return await movieQuery.ToListAsync();
        }

        public async Task<List<Movie>> GetMoviesByGenreAndRatingAsync(List<int> genreIDs, List<int> ratingIDs)
        {
            var movieQuery = _context.Movies
                .Include(m => m.Genres)
                .Include(m => m.Rating)
                .Include(m => m.MoviePoster)
                .AsQueryable();
            if (genreIDs != null && genreIDs.Any())
            {
                movieQuery = movieQuery.Where(m =>
                    genreIDs.All(gid => m.Genres.Select(g => g.Id).Contains(gid))
                );
            }
            if (ratingIDs != null && ratingIDs.Any())
            {
                movieQuery = movieQuery.Where(m =>
                    ratingIDs.Contains(m.RatingId)
                );
            }
            return await movieQuery.ToListAsync();
        }
    }
}
