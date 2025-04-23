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
                .ToListAsync();
        }

        public async Task<List<Movie>> GetMoviesByGenreAsync(List<int> genreIDs)
        {
            var movieQuery = _context.Movies
                .Include(m => m.Genres)
                .Include(m => m.Rating)
                .AsQueryable();

            if (genreIDs != null && genreIDs.Any())
            {
                movieQuery = movieQuery.Where(m =>
                   genreIDs.All(gid => m.Genres.Select(g => g.Id).Contains(gid))
                 );
                   
            }

            return await movieQuery.ToListAsync();
        }
    }
}
