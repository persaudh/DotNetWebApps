using Microsoft.EntityFrameworkCore;
using MovieDirectoryDotNetCoreMVC.Data;

namespace MovieDirectoryDotNetCoreMVC.Services
{
    public class GenreService : IGenreService
    {
        private readonly MovieDirectoryContext _context;
        public GenreService(MovieDirectoryContext context)
        {
            _context = context;
        }

        public async Task<List<Genre>> GetAllGenresAsync()
        {
            return await _context.Genres
                .Include(g => g.Movies)
                .OrderBy(g => g.Name)
                .ToListAsync();
        }
    }
}
