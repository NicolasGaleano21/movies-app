namespace Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required int GenreId { get; set; }
        public List<MovieActor> MovieActors { get; set; } = [];
        public List<MovieGenre> MovieGenres { get; set; } = [];
    }
}
