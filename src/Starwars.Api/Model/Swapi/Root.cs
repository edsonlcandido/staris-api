
namespace Starwars.Api.Model.Swapi;
public class Root<T>
{
    public List<T> results { get; set; }
    public int count { get; set; }
    public string next { get; set; }
    public string previous { get; set; }    
}