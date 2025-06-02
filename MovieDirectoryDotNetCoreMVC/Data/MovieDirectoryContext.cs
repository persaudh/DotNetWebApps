using Microsoft.EntityFrameworkCore;

namespace MovieDirectoryDotNetCoreMVC.Data
{
    public class MovieDirectoryContext : DbContext
    {
        public MovieDirectoryContext(DbContextOptions<MovieDirectoryContext> options) : base(options)
        {
        }
        // <summary>
        /// DbSet properties for each entity in the database
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        /// <summary>
        /// Override the OnModelCreating method to configure the relationships between entities
        /// </summary>
        /// <param name="modelBuilder"></param>
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

            modelBuilder.Entity<Movie>()
                .HasOne(m => m.MoviePoster)
                .WithOne(mp => mp.Movie)
                .HasForeignKey<MoviePoster>(m => m.Id);
        }
    }
}
