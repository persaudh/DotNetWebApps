using MovieDirectoryDotNetCoreMVC.Data;

namespace MovieDirectoryDotNetCoreMVC.Models
{
    public class IndexViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<int> SelectGenreIds { get; set; }
        public IndexViewModel() { }
    }
}
