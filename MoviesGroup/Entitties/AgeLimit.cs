﻿
namespace MoviesGroup.Entitties;

public class AgeLimit : IEntity
{
    public int Id { get; set; }
    public int Limit { get; set; }
    public List<Movie> Movies { get; set; }
}
