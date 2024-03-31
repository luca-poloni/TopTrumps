using MediatR;

namespace Application.UseCases.Game.Queries.GetAllGames
{
    public record GetAllGamesRequest : IRequest<IEnumerable<GetAllGamesResponse>> { } 
}
