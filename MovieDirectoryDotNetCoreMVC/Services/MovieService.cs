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
    }
}
