namespace Kaamiflix.Membership.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FilmController : ControllerBase
{
    private IDbService _db;

    public FilmController(IDbService db) => _db = db;
    [HttpGet]
    public async Task<IResult> Get(bool freeOnly)
    {
        try
        {
            _db.Include<Director>();

            List<FilmDTO> films = null;

            if (freeOnly)
            {
                films = await _db.GetAsync<Film, FilmDTO>(f => f.Free.Equals(freeOnly));

            }
            else
            {
                films = await _db.GetAsync<Film, FilmDTO>();
            }

            return Results.Ok(films);
        }
        catch { }
        return Results.NotFound();

    }

    [HttpGet("{id}")]
    public async Task<IResult> Get(int id)
    {
        try
        {
            _db.Include<Director>();
            _db.IncludeGenreAndSimilar(id);


            var film = await _db.SingleAsync<Film, FilmDTO>(f => f.Id.Equals(id));
            if (film is null)
                return Results.NotFound();

            return Results.Ok(film);
        }
        catch
        { }
        return Results.NotFound();
    }
    [HttpPost]
    public async Task<IResult> Post([FromBody] FilmCreateDTO dto)
    {
        try
        {
            if (dto is null)
                return Results.BadRequest();

            var film = await _db.AddAsync<Film, FilmCreateDTO>(dto);

            var success = await _db.SaveChangesAsync();

            if (success)

                return Results.Created(_db.GetURI<Film>(film), film);
            else
                return Results.BadRequest();
        }
        catch
        {

        }

        return Results.BadRequest();

    }
    [HttpPut("{id}")]
    public async Task<IResult> Put(int id, [FromBody] FilmEditDTO dto)
    {

        try
        {
            if (dto is null || !dto.Id.Equals(id)) return Results.BadRequest();

            var exists = await _db.AnyAsync<Director>(d => d.Id.Equals(dto.DirectorId));
            if (!exists)
                return Results.NotFound();


            exists = await _db.AnyAsync<Film>(f => f.Id.Equals(id));
            if (!exists)
                return Results.NotFound();

            _db.Update<Film, FilmEditDTO>(id, dto);

            var success = await _db.SaveChangesAsync();

            if (success) return Results.NoContent();
            else
                return Results.BadRequest();


        }
        catch
        {

        }

        return Results.BadRequest();

    }
    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id)
    {
        try
        {
            var success = await _db.DeleteAsync<Film>(id);

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
