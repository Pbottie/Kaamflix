namespace Kaamiflix.Membership.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DirectorController : ControllerBase
{
    private IDbService _db;

    public DirectorController(IDbService db) => _db = db;
    [HttpGet]
    public async Task<IResult> Get()
    {
        try
        {
            List<DirectorDTO> directors = null;
            directors = await _db.GetAsync<Director, DirectorDTO>();
            return Results.Ok(directors);
        }
        catch
        { }
        return Results.NotFound();

    }

    [HttpGet("{id}")]
    public async Task<IResult> Get(int id)
    {
        try
        {
            var director = await _db.SingleAsync<Director, DirectorDTO>(d => d.Id.Equals(id));
            if (director is null)
                return Results.NotFound();

            return Results.Ok(director);
        }
        catch
        { }
        return Results.NotFound();

    }
    [HttpPost]
    public async Task<IResult> Post([FromBody] DirectorDTO dto)
    {

        try
        {
            if (dto is null)
                return Results.BadRequest();

            var director = await _db.AddAsync<Director, DirectorDTO>(dto);

            var success = await _db.SaveChangesAsync();

            if (success)

                return Results.Created(_db.GetURI<Director>(director), director);
            else
                return Results.BadRequest();


        }
        catch
        {

        }

        return Results.BadRequest();

    }
    [HttpPut("{id}")]
    public async Task<IResult> Put(int id, [FromBody] DirectorDTO dto)
    {

        try
        {
            if (dto is null || !dto.Id.Equals(id)) return Results.BadRequest();

            var exists = await _db.AnyAsync<Director>(d => d.Id.Equals(id));
            if (!exists)
                return Results.NotFound();

            _db.Update<Director, DirectorDTO>(id, dto);

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
            var success = await _db.DeleteAsync<Director>(id);

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
