namespace MovieDirectoryDotNetCoreMVC.Data
{
    public class Rating
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        // Navigation property
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
