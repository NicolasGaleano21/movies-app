using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class MoviesDbContext(DbContextOptions<MoviesDbContext> options) : DbContext(options)
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define primary keys

            modelBuilder.Entity<Movie>().HasKey(m => m.Id);
            modelBuilder.Entity<MovieActor>().HasKey(ma => new { ma.MovieId, ma.ActorId });
            modelBuilder.Entity<MovieGenre>().HasKey(mg => new { mg.MovieId, mg.GenreId });
            modelBuilder.Entity<Genre>().HasKey(g => g.Id);

            // Define relationships

            modelBuilder
                .Entity<MovieActor>()
                .HasOne(ma => ma.Movie)
                .WithMany(m => m.MovieActors)
                .HasForeignKey(ma => ma.MovieId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder
                .Entity<MovieGenre>()
                .HasOne(mg => mg.Movie)
                .WithMany(m => m.MovieGenres)
                .HasForeignKey(mg => mg.MovieId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder
                .Entity<MovieActor>()
                .HasOne(ma => ma.Actor)
                .WithMany(a => a.MovieActors)
                .HasForeignKey(ma => ma.ActorId)
                .OnDelete(DeleteBehavior.NoAction);

            // Seed initial genres
            var genres = new List<Genre>
            {
                new() { Id = 1, Description = "Action" },
                new() { Id = 2, Description = "Comedy" },
                new() { Id = 3, Description = "Drama" },
                new() { Id = 4, Description = "Horror" },
                new() { Id = 5, Description = "Sci-Fi" },
            };
            modelBuilder.Entity<Genre>().HasData(genres);

            // Seed initial actors
            var actors = new List<Actor>
            {
                new() { Id = 1, Name = "Robert Downey Jr." },
                new() { Id = 2, Name = "Scarlett Johansson" },
                new() { Id = 3, Name = "Chris Evans" },
                new() { Id = 4, Name = "Tom Hardy" },
                new() { Id = 5, Name = "Natalie Portman" },
                new() { Id = 6, Name = "Leonardo DiCaprio" },
                new() { Id = 7, Name = "Jennifer Lawrence" },
                new() { Id = 8, Name = "Brad Pitt" },
                new() { Id = 9, Name = "Angelina Jolie" },
                new() { Id = 10, Name = "Keanu Reeves" },
            };
            modelBuilder.Entity<Actor>().HasData(actors);

            // Seed initial movies
            var movies = Enumerable
                .Range(1, 30)
                .Select(i => new Movie
                {
                    Id = i,
                    Title = $"Movie {i}",
                    GenreId = (i % 5) + 1,
                })
                .ToList();
            modelBuilder.Entity<Movie>().HasData(movies);

            // Seed movie-genre relationships
            var movieGenres = movies
                .Select(m => new MovieGenre { MovieId = m.Id, GenreId = m.GenreId })
                .ToList();
            modelBuilder.Entity<MovieGenre>().HasData(movieGenres);

            // Seed movie-actor relationships
            var movieActors = new List<MovieActor>();
            for (int i = 1; i <= 30; i++)
            {
                var assignedActors = Enumerable
                    .Range(0, 3)
                    .Select(j => new MovieActor { MovieId = i, ActorId = ((i + j) % 10) + 1 })
                    .ToList();

                movieActors.AddRange(assignedActors);
            }
            modelBuilder.Entity<MovieActor>().HasData(movieActors);
        }
    }
}
