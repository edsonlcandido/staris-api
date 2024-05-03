
namespace Starwars.Api.Model.Swapi;
public class Root<T>
{
    public List<T> Results { get; set; }
    public int Count { get; set; }
    public string Next { get; set; }
    public string Previous { get; set; }    
}