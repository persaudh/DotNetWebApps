namespace MovieDirectory.Services
{
    public interface IMovieService
    {
        public Task<List<Movie>> GetMoviesAsync();
        public Task AddMovieAsync(Movie movie);
        public Task<bool> UpdateMovieAsync(Movie movie);
        public Task<bool> DeleteMovieAsync(int id);
        public Task<List<Movie>> RestMovieAsync();
    }
}
