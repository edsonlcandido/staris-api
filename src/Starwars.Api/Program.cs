using EvolveDb;
using Microsoft.Data.Sqlite;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory());
var cnx = new SqliteConnection($@"Data Source={System.IO.Path.Combine(outputPath,"app.db")}");
var evolve = new Evolve(cnx)
{
    Locations = new List<string> { "Data/Migrations" },
    IsEraseDisabled = true,
};

evolve.Migrate();

app.MapGet("/", () => "Hello World!");

app.Run();
