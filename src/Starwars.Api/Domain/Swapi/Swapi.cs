using System.Text.Json;
using Starwars.Api.Model.Swapi.Film;

public class Swapi
{
    public async Task<Root> GetFilms()
    {
        var client = new HttpClient();
        var response = await client.GetAsync("https://swapi.py4e.com/api/films/?format=json");
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Root>(content);         
    }
}