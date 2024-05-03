using Starwars.Api.Data.Entites;

public class GetMoviesQuery
{
    public  async Task<IEnumerable<Movie>> Query(){
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
                        Id = film.id,
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
            return result;
    }
}
