namespace Kaamiflix.Membership.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenreController : ControllerBase
{
    private IDbService _db;

    public GenreController(IDbService db) => _db = db;
    [HttpGet]
    public async Task<IResult> Get()
    {
        try
        {
            List<GenreDTO> genres = null;
            genres = await _db.GetAsync<Genre, GenreDTO>();
            return Results.Ok(genres);
        }
        catch { }
        return Results.NotFound();
    }

    [HttpGet("{id}")]
    public async Task<IResult> Get(int id)
    {
        try
        {
            var genre = await _db.SingleAsync<Genre, GenreDTO>(g => g.Id.Equals(id));
            if (genre is null)
                return Results.NotFound();
            return Results.Ok(genre);
        }
        catch
        { }
        return Results.NotFound();
    }
    [HttpPost]
    public async Task<IResult> Post([FromBody] GenreCreateDTO dto)
    {
        try
        {
            if (dto is null)
                return Results.BadRequest();

            var genre = await _db.AddAsync<Genre, GenreCreateDTO>(dto);
            var success = await _db.SaveChangesAsync();

            if (success)
                return Results.Created(_db.GetURI<Genre>(genre), genre);
            else
                return Results.BadRequest();
        }
        catch { }
        return Results.BadRequest();
    }
    [HttpPut("{id}")]
    public async Task<IResult> Put(int id, [FromBody] GenreEditDTO dto)
    {

        try
        {
            if (dto is null || !dto.Id.Equals(id)) return Results.BadRequest();
            var exists = await _db.AnyAsync<Genre>(g => g.Id.Equals(id));
            if (!exists)
                return Results.NotFound();

            _db.Update<Genre, GenreEditDTO>(id, dto);
            var success = await _db.SaveChangesAsync();

            if (success) return Results.NoContent();
            else
                return Results.BadRequest();
        }
        catch { }
        return Results.BadRequest();
    }
    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id)
    {
        try
        {
            var success = await _db.DeleteAsync<Genre>(id);

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
