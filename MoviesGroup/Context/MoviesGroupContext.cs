using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;

namespace MoviesGroup.Context;

public class MoviesGroupContext(DbContextOptions<MoviesGroupContext> builder) : DbContext(builder)
{
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Filter> Filters => Set<Filter>();
    public DbSet<Actor> Actors => Set<Actor>();
    public DbSet<AgeLimit> AgeLimits => Set<AgeLimit>();
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<ReleaseYear> ReleaseYears => Set<ReleaseYear>();
    public DbSet<StreamingService> StreamingServices => Set<StreamingService>();
    public DbSet<GenreFilter> GenreFilters => Set<GenreFilter>();
    public DbSet<MovieGenre> MovieGenres => Set<MovieGenre>();
    public DbSet<MovieActor> MovieActors => Set<MovieActor>();
    public DbSet<MovieAgeLimit> MovieAgeLimits => Set<MovieAgeLimit>();
    public DbSet<MovieStreamingService> MovieStreamingServices => Set<MovieStreamingService>();
    public DbSet<MovieReleaseYear> MovieReleaseYears => Set<MovieReleaseYear>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Composite Keys
        builder.Entity<MovieActor>()
            .HasKey(ma => new { ma.MovieId, ma.ActorId });
        builder.Entity<MovieAgeLimit>()
            .HasKey(mal => new { mal.MovieId, mal.AgeLimitId });
        builder.Entity<MovieGenre>()
            .HasKey(mg => new { mg.MovieId, mg.GenreId });
        builder.Entity<GenreFilter>()
            .HasKey(gf => new { gf.GenreId, gf.FilterId });
        builder.Entity<MovieReleaseYear>()
            .HasKey(mry => new { mry.MovieId, mry.ReleaseYearId });
        builder.Entity<MovieStreamingService>()
    .HasKey(mss => new { mss.MovieId, mss.StreamingServiceId });
        #endregion

        #region GenreFilter Many-to-Many Relationship

        builder.Entity<Genre>()
            .HasMany(g => g.Filters)
            .WithMany(f => f.Genres)
            .UsingEntity<GenreFilter>();
        #endregion

        #region MovieGenre Many-to-Many Relationship
        builder.Entity<Movie>()
            .HasMany(m => m.Genres)
            .WithMany(g => g.Movies)
            .UsingEntity<MovieGenre>();
        #endregion

        #region MovieActor Many-to-Many Relationship
        builder.Entity<Movie>()
            .HasMany(m => m.Actors)
            .WithMany(a => a.Movies)
            .UsingEntity<MovieActor>();
        #endregion

        #region MovieAgeLimit Many-to-One Relationship
        builder.Entity<Movie>()
            .HasOne(m => m.AgeLimit)
            .WithMany(al => al.Movies)
            .UsingEntity<MovieAgeLimit>();
        #endregion

        #region MovieReleaseYear Many-to-One Relationship
        builder.Entity<Movie>()
            .HasMany(m => m.ReleaseYear)
            .WithMany(ry => ry.Movies)
            .UsingEntity<MovieReleaseYear>();
        #endregion

        #region MovieStreamingService Many-to-One Relationship
        builder.Entity<Movie>()
            .HasMany(m => m.StreamingService)
            .WithMany(ss => ss.Movies)
            .UsingEntity<MovieStreamingService>();
        #endregion

    }

}
{
}
