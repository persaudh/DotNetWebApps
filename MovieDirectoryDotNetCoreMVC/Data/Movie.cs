namespace MovieDirectoryDotNetCoreMVC.Data
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public int RatingId { get; set; }
        public Rating Rating { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
