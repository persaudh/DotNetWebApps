using MovieDirectoryDotNetCoreMVC.Data;

namespace MovieDirectoryDotNetCoreMVC.Services
{
    public interface IMovieService
    {
        public Task<List<Movie>> GetAllMoviesAsync();
    }
}
