using EvolveDb;
using MediatR;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Starwars.Api.Data.Entites;

var outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory());
var cnx = new SqliteConnection($@"Data Source=./app.db");
var evolve = new Evolve(cnx)
{
    Locations = new List<string> { "Data/Migrations" },
    IsEraseDisabled = true,
};
evolve.Migrate();

var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.MapGet("/movies", async () =>
{
    var result = await new GetMoviesQuery().Query();
    return Results.Ok(result);
});

app.Run();