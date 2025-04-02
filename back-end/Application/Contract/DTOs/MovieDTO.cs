namespace Application.Contract.DTOs
{
    public class MovieDTO
    {
        public required string Title { get; set; }
        public List<ActorDTO> Actors { get; set; } = null!;
        public List<GenreDTO> Genres { get; set; } = null!;
    }
}
