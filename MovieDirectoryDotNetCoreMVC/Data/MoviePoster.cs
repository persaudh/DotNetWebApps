namespace MovieDirectoryDotNetCoreMVC.Data
{
    public class MoviePoster
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string LocalPath { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Movie Movie { get; set; }

    }
}
