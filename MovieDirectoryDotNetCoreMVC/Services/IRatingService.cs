using MovieDirectoryDotNetCoreMVC.Data;

namespace MovieDirectoryDotNetCoreMVC.Services
{
    public interface IRatingService
    {
        public Task<List<Rating>> GetAllRatingAsync();
    }
}
