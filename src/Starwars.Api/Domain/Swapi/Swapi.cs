using System.Text.Json;
using Starwars.Api.Model.Swapi.Film;

public class Swapi
{
    public async Task<Root> GetFilms()
    {
        var client = new HttpClient();
        var response = await client.GetAsync("https://swapi.py4e.com/api/films/?format=json");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Root>(content); 
        return result;
    }
}