namespace Kaamiflix.Common.Services;

public class MembershipService : IMembershipService
{
    protected readonly MembershipHttpClient _http;

    public MembershipService(MembershipHttpClient httpClient)
    {
        _http = httpClient;
    }

    public async Task<List<FilmDTO>> GetFilmsAsync()
    {
        try
        {

            using HttpResponseMessage response = await _http.Client.GetAsync($"film");
            response.EnsureSuccessStatusCode();

            var result = JsonSerializer.Deserialize<List<FilmDTO>>(await
                response.Content.ReadAsStreamAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result ?? new List<FilmDTO>();


        }
        catch (Exception)
        {
            return new List<FilmDTO>();
        }


    }
    public async Task<FilmDTO> GetFilmAsync(int? id)
    {
        try
        {
            if (id is null)
                return new FilmDTO();

            using HttpResponseMessage response = await _http.Client.GetAsync($"film/{id}");
            response.EnsureSuccessStatusCode();

            var result = JsonSerializer.Deserialize<FilmDTO>(await
                response.Content.ReadAsStreamAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result ?? new FilmDTO();

        }
        catch (Exception)
        {

            return new FilmDTO();
        }
    }
    public async Task<DirectorDTO> GetDirectorAsync(int? id)
    {
        try
        {
            if (id is null)
                return new DirectorDTO();

            using HttpResponseMessage response = await _http.Client.GetAsync($"director/{id}");
            response.EnsureSuccessStatusCode();

            var result = JsonSerializer.Deserialize<DirectorDTO>(await
                response.Content.ReadAsStreamAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result ?? new DirectorDTO();
        }
        catch (Exception)
        {
            return new DirectorDTO();
        }
    }
    public async Task<List<GenreDTO>> GetGenresAsync()
    {
        try
        {
            using HttpResponseMessage response = await _http.Client.GetAsync($"genre");
            response.EnsureSuccessStatusCode();

            var result = JsonSerializer.Deserialize<List<GenreDTO>>(await
                response.Content.ReadAsStreamAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result ?? new List<GenreDTO>();


        }
        catch (Exception)
        {
            return new List<GenreDTO>();
        }


    }



}

