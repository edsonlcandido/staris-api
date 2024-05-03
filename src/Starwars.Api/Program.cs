using EvolveDb;
using Microsoft.Data.Sqlite;
using Starwars.Api.Data.Entites;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory());
var cnx = new SqliteConnection($@"Data Source=./app.db");
var evolve = new Evolve(cnx)
{
    Locations = new List<string> { "Data/Migrations" },
    IsEraseDisabled = true,
};
evolve.Migrate();



app.MapGet("/", () => "Hello World!");

app.MapGet("/movies", async () =>
{
    IRepository<Movie> movies = new Repository<Movie>();
    var result = await movies.GetAll();
    if (result.Count() == 0)
    {
        var swapi = new Swapi();
        var swapiMovies = await swapi.GetFilms();
        foreach (var film in swapiMovies.results)
        {
            await movies.Add(new Movie
            {
                Title = film.title,
                Episode = film.episode_id,
                OpeningCrawl = film.opening_crawl,
                Director = film.director,
                Producer = film.producer,
                ReleaseDate = film.release_date
            });
        }
        result = await movies.GetAll();
    };
    
    return Results.Ok(result);
});

app.Run();
