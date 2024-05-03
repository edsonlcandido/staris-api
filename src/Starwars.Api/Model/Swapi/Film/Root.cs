using System.Text.Json.Serialization;

namespace Starwars.Api.Model.Swapi.Film{
    public class Root
    {
        public List<Film> results { get; set; }
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }    
    }
}
