namespace Kaamiflix.Membership.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SimilarFilmController : ControllerBase
{
    private IDbService _db;
    public SimilarFilmController(IDbService db) => _db = db;
    [HttpGet]
    public async Task<IResult> Get()
    {
        try
        {
            var similarFilms = await _db.GetRefAsync<SimilarFilm, SimilarFilmCreateDTO>();

            return Results.Ok(similarFilms);
        }
        catch { }
        return Results.NotFound();

    }
    [HttpPost]
    public async Task<IResult> Post([FromBody] SimilarFilmCreateDTO dto)
    {
        try
        {
            var entity = await _db.AddAsync<SimilarFilm, SimilarFilmCreateDTO>(dto);
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
    public async Task<IResult> Delete(SimilarFilmCreateDTO dto)
    {
        try
        {
            var success = _db.Delete<SimilarFilm, SimilarFilmCreateDTO>(dto);

            if (!success)
                return Results.NotFound();

            success = await _db.SaveChangesAsync();

            if (success) return Results.NoContent();
            else
                return Results.BadRequest();

        }
        catch { }
        return Results.BadRequest();
    }
}
