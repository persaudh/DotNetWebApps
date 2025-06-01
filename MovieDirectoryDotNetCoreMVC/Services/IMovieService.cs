using MovieDirectoryDotNetCoreMVC.Data;

namespace MovieDirectoryDotNetCoreMVC.Services
{
    public interface IMovieService
    {
        public Task<List<Movie>> GetAllMoviesAsync();
        public Task<List<Movie>> GetMoviesByGenreAsync(List<int> genreIDs);
        public Task<List<Movie>> GetMoviesByRatingAsync(List<int> ratingIDs);
        public Task<List<Movie>> GetMoviesByGenreAndRatingAsync(List<int> genreIDs, List<int> ratingIDs);
    }
}
