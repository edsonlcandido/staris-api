using MediatR;
using Starwars.Api.Data.Entites;

public class GetMoviesCommand : IRequest<IEnumerable<Movie>>
    {
    }