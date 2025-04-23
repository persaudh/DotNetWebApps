using MovieDirectoryDotNetCoreMVC.Data;

namespace MovieDirectoryDotNetCoreMVC.Services
{
    public interface IMovieService
    {
        public Task<List<Movie>> GetAllMoviesAsync();
        public Task<List<Movie>> GetMoviesByGenreAsync(List<int> genreIDs);
    }
}
