﻿namespace Kaamiflix.Membership.Database.Entities;

public class Film : IEntity
{
    public Film()
    {
        SimilarFilms = new HashSet<SimilarFilm>();
        Genres = new HashSet<Genre>();
    }
    public int Id { get; set; }
    [Required, MaxLength(50)] public string Title { get; set; } = null!;
    public DateTime Released { get; set; }
    public int DirectorId { get; set; }
    public bool Free { get; set; }
    [MaxLength(200)] public string Description { get; set; } = null!;
    [MaxLength(1024)] public string FilmUrl { get; set; } = null!;
    [MaxLength(200)] public string ImageUrl { get; set; } = null!;
    [MaxLength(200)] public string MarqueeImageUrl { get; set; } = null!;

    public virtual ICollection<SimilarFilm> SimilarFilms { get; set; }
    public virtual ICollection<Genre> Genres { get; set; }
    public virtual Director Director { get; set; } = null!;
}
