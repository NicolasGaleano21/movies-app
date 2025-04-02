namespace Domain.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<MovieActor>? MovieActors { get; set; }
    }
}
