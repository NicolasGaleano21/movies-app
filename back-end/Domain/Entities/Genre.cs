namespace Domain.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}
