namespace Kaamiflix.Membership.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilmGenreController : ControllerBase
{
    private IDbService _db;
    public FilmGenreController(IDbService db) => _db = db;


    [HttpGet]
    public async Task<IResult> Get()
    {
        try
        {
            var filmGenres = await _db.GetRefAsync<FilmGenre, FilmGenreDTO>();

            return Results.Ok(filmGenres);
        }
        catch { }
        return Results.NotFound();

    }



    [HttpPost]
    public async Task<IResult> Post([FromBody] FilmGenreDTO dto)
    {
        try
        {
            var entity = await _db.AddAsync<FilmGenre, FilmGenreDTO>(dto);
            if (await _db.SaveChangesAsync())
            {
                return Results.NoContent();
            }
        }
        catch
        {
            return Results.BadRequest();
        }
        return Results.BadRequest();
    }
    [HttpDelete]
    public async Task<IResult> Delete(FilmGenreDTO dto)
    {
        try
        {
            var success = _db.Delete<FilmGenre, FilmGenreDTO>(dto);

            if (!success)
                return Results.NotFound();

            success = await _db.SaveChangesAsync();

            if (success) return Results.NoContent();
            else
                return Results.BadRequest();

        }
        catch (Exception)
        {

        }
        return Results.BadRequest();
    }
}
