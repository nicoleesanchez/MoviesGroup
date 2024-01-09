using MoviesGroup.Shared.Enums;

namespace MoviesGroup.Entitties;

public class Filter : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string TypeName { get; set; }
    public OptionType OptionType { get; set; }
    public List<Genre>? Genres { get; set; }
}
