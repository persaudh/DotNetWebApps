using Microsoft.EntityFrameworkCore;
using MovieDirectoryDotNetCoreMVC.Data;

namespace MovieDirectoryDotNetCoreMVC.Services
{
    public class RatingService : IRatingService
    {
        private MovieDirectoryContext _context;
        public RatingService(MovieDirectoryContext context)
        {
            _context = context;
        }
        public async Task<List<Rating>> GetAllRatingAsync()
        {
            return await _context.Ratings
                .Include(r => r.Movies)
                .OrderBy(r => r.Id)
                .ToListAsync();
        }
    }
}
