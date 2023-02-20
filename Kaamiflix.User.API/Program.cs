var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsAllAccessPolicy", opt =>
    opt.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    );
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<FlixContext>(
    options => options.UseSqlServer(
        builder.Configuration
        .GetConnectionString("KaamiflixConnection")));

var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.CreateMap<Film, FilmDTO>().ReverseMap()
    .ForMember(dest => dest.Genres, src => src.Ignore());

    cfg.CreateMap<Director, DirectorDTO>().ReverseMap()
    .ForMember(dest => dest.Films, src => src.Ignore());

    cfg.CreateMap<Genre, GenreDTO>()
    .ForMember(dest => dest.Films, src => src.Ignore())
    .ReverseMap();


    cfg.CreateMap<SimilarFilm, SimilarFilmDTO>()
    .ForMember(dest => dest.Film, src => src.Ignore())
    .ReverseMap();
    //.ForMember(dest => dest.Film, src => src.MapFrom(s => s.Film.Title))
    //.ReverseMap()
    //.ForMember(dest => dest.Film, src => src.Ignore());

    cfg.CreateMap<FilmGenre, FilmGenreDTO>().ReverseMap();

    cfg.CreateMap<FilmCreateDTO, Film>()
    .ForMember(dest => dest.Id, src => src.Ignore())
    .ForMember(dest => dest.SimilarFilms, src => src.Ignore())
    .ForMember(dest => dest.Genres, src => src.Ignore())
    .ForMember(dest => dest.Director, src => src.Ignore());

    cfg.CreateMap<FilmEditDTO, Film>()
    .ForMember(dest => dest.SimilarFilms, src => src.Ignore())
    .ForMember(dest => dest.Genres, src => src.Ignore())
    .ForMember(dest => dest.Director, src => src.Ignore()); ;


    cfg.CreateMap<GenreCreateDTO, Genre>();
    cfg.CreateMap<GenreEditDTO, Genre>();

    cfg.CreateMap<SimilarFilmCreateDTO, SimilarFilm>().ReverseMap();

});

//TEST
//config.AssertConfigurationIsValid();
//var description = config.BuildExecutionPlan(typeof(GenreDTO), typeof(Genre));
//Console.WriteLine(description.ToReadableString());
//

var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IDbService, DbService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsAllAccessPolicy");
app.UseAuthorization();


app.MapControllers();

app.Run();