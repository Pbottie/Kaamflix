namespace Kaamiflix.Common.Services
{
    public interface IMembershipService
    {
        Task<FilmDTO> GetFilmAsync(int? id);
        Task<List<FilmDTO>> GetFilmsAsync();
        Task<DirectorDTO> GetDirectorAsync(int? id);
        Task<List<GenreDTO>> GetGenresAsync();
    }
}