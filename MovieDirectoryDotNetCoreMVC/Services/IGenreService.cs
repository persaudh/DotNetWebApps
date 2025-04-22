using MovieDirectoryDotNetCoreMVC.Data;

namespace MovieDirectoryDotNetCoreMVC.Services
{
    public interface IGenreService
    {
        public Task<List<Genre>> GetAllGenresAsync();
    }
}
