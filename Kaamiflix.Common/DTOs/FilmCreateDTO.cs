namespace Kaamiflix.Common.DTOs;

public class FilmCreateDTO
{
    public string Title { get; set; } = null!;
    public DateTime Released { get; set; }
    public int DirectorId { get; set; }
    public bool Free { get; set; }
    public string Description { get; set; } = null!;
    public string FilmUrl { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string MarqueeImageUrl { get; set; } = null!;

}
