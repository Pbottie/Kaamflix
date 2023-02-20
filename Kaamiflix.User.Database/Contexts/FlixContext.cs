namespace Kaamiflix.Membership.Database.Contexts;

public class FlixContext : DbContext
{
    public virtual DbSet<Film> Films { get; set; } = null!;
    public virtual DbSet<SimilarFilm> SimilarFilms { get; set; } = null!;
    public virtual DbSet<Director> Directors { get; set; } = null!;
    public virtual DbSet<Genre> Genres { get; set; } = null!;
    public virtual DbSet<FilmGenre> FilmGenres { get; set; } = null!;

    public FlixContext(DbContextOptions<FlixContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Restricts Cascading deletes
        foreach (var relationship in modelBuilder.Model
            .GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        modelBuilder.Entity<SimilarFilm>().HasKey(ck => new { ck.FilmId, ck.SimilarFilmId });
        modelBuilder.Entity<FilmGenre>().HasKey(ck => new { ck.FilmId, ck.GenreId });

        modelBuilder.Entity<Film>(entity =>
        {
            entity
            .HasMany(f => f.SimilarFilms)
            .WithOne(sf => sf.Film)
            .HasForeignKey(f => f.FilmId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            entity
            .HasMany(f => f.Genres)
            .WithMany(g => g.Films)
            .UsingEntity<FilmGenre>()
            .ToTable("FilmGenres");
        });


        #region Seed Data
        //modelBuilder.Entity<Director>().HasData(
        //    new Director { Id = 1, Name = "Frank Gold" },
        //    new Director { Id = 2, Name = "Stephan Manberg" },
        //    new Director { Id = 3, Name = "Charlie Night" },
        //    new Director { Id = 4, Name = "Jane Fresh" },
        //    new Director { Id = 5, Name = "Hera Gomu" },
        //    new Director { Id = 6, Name = "Nadia Naka" }
        //    );

        //modelBuilder.Entity<Film>().HasData(
        //    new Film
        //    {
        //        Id = 1,
        //        Title = "Spiderman",
        //        Released = new DateTime(2010, 11, 20),
        //        DirectorId = 1,
        //        Free = true,
        //        Description = "Lorem",
        //        FilmUrl = "YOUTUBE",
        //        ImageUrl = "",
        //        MarqueeImageUrl =""

        //    },
        //    new Film
        //    {
        //        Id = 2,
        //        Title = "Batman",
        //        Released = new DateTime(2012, 1, 2),
        //        DirectorId = 2,
        //        Free = true,
        //        Description = "Ipsum",
        //        FilmUrl = "YOUTUBE",
        //        ImageUrl = "",
        //        MarqueeImageUrl = ""
        //    },
        //    new Film
        //    {
        //        Id = 3,
        //        Title = "The Hulk",
        //        Released = new DateTime(2005, 10, 25),
        //        DirectorId = 3,
        //        Free = true,
        //        Description = "Campins",
        //        FilmUrl = "YOUTUBE",
        //        ImageUrl = "",
        //        MarqueeImageUrl = ""
        //    },
        //    new Film
        //    {
        //        Id = 4,
        //        Title = "The Shining",
        //        Released = new DateTime(1990, 12, 24),
        //        DirectorId = 4,
        //        Free = false,
        //        Description = "Changer",
        //        FilmUrl = "YOUTUBE",
        //        ImageUrl = "",
        //        MarqueeImageUrl = ""
        //    },
        //    new Film
        //    {
        //        Id = 5,
        //        Title = "Godzilla",
        //        Released = new DateTime(1970, 5, 8),
        //        DirectorId = 5,
        //        Free = false,
        //        Description = "Krens",
        //        FilmUrl = "YOUTUBE",
        //        ImageUrl = "",
        //        MarqueeImageUrl = ""
        //    },
        //    new Film
        //    {
        //        Id = 6,
        //        Title = "The Ring",
        //        Released = new DateTime(2018, 6, 23),
        //        DirectorId = 6,
        //        Free = false,
        //        Description = "Hegerd",
        //        FilmUrl = "YOUTUBE",
        //        ImageUrl = "",
        //        MarqueeImageUrl = ""
        //    }

        //    );

        //modelBuilder.Entity<SimilarFilm>().HasData(
        //    new SimilarFilm { FilmId = 1, SimilarFilmId = 2 },
        //    new SimilarFilm { FilmId = 1, SimilarFilmId = 3 },
        //    new SimilarFilm { FilmId = 2, SimilarFilmId = 1 },
        //    new SimilarFilm { FilmId = 2, SimilarFilmId = 3 },
        //    new SimilarFilm { FilmId = 3, SimilarFilmId = 1 },
        //    new SimilarFilm { FilmId = 3, SimilarFilmId = 2 },
        //    new SimilarFilm { FilmId = 4, SimilarFilmId = 6 },
        //    new SimilarFilm { FilmId = 6, SimilarFilmId = 4 },
        //    new SimilarFilm { FilmId = 5, SimilarFilmId = 3 }
        //    );

        //modelBuilder.Entity<Genre>().HasData(
        //    new Genre { Id = 1, Name = "Action" },
        //    new Genre { Id = 2, Name = "Sci-Fi" },
        //    new Genre { Id = 3, Name = "Thriller" },
        //    new Genre { Id = 4, Name = "Horror" },
        //    new Genre { Id = 5, Name = "Comedy" },
        //    new Genre { Id = 6, Name = "Romance" }
        //    );

        //modelBuilder.Entity<FilmGenre>().HasData(
        //    new FilmGenre { FilmId = 1, GenreId = 1 },
        //    new FilmGenre { FilmId = 1, GenreId = 2 },
        //    new FilmGenre { FilmId = 2, GenreId = 1 },
        //    new FilmGenre { FilmId = 3, GenreId = 1 },
        //    new FilmGenre { FilmId = 4, GenreId = 4 },
        //    new FilmGenre { FilmId = 5, GenreId = 5 },
        //    new FilmGenre { FilmId = 6, GenreId = 4 },
        //    new FilmGenre { FilmId = 6, GenreId = 6 }
        //    );
        #endregion
    }



}

