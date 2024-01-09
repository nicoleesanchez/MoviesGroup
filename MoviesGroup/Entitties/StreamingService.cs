namespace MoviesGroup.Entitties;

public class StreamingService : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Movie> Movies { get; set; }
}
