using Microsoft.EntityFrameworkCore;

namespace MovieDirectoryDotNetCoreMVC.Data
{
    public class MovieDirectoryContext : DbContext
    {
        public MovieDirectoryContext(DbContextOptions<MovieDirectoryContext> options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Genres)
                .WithMany(g => g.Movies)
                .UsingEntity(j => j.ToTable("MovieGenres"));

            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Rating)
                .WithMany(r => r.Movies)
                .HasForeignKey(m => m.RatingId);

            
        }
    }
}
