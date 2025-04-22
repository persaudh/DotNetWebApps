using MovieDirectoryDotNetCoreMVC.Data;

namespace MovieDirectoryDotNetCoreMVC.Models
{
    public class IndexViewModel
    {
        public List<Movie> Movies { get; set; }
        public IndexViewModel() { }
    }
}
