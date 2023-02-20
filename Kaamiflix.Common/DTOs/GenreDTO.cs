namespace Kaamiflix.Common.DTOs;

public class GenreDTO
{

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<FilmDTO> Films { get; set; } = null!;

}
