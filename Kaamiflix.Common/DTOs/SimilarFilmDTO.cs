namespace Kaamiflix.Common.DTOs;

public  class SimilarFilmDTO
{
    public int FilmId { get; set; }
    public int SimilarFilmId { get; set; }
    public FilmDTO Film { get; set; } = null!;
    public FilmDTO Similar { get; set; } = null!;


}
