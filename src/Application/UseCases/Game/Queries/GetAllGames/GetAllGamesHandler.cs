using Ardalis.SharedKernel;
using Domain.Game;
using MediatR;

namespace Application.UseCases.Game.Queries.GetAllGames
{
    internal class GetAllGamesHandler(IReadRepository<GameAggregate> repository) : IRequestHandler<GetAllGamesRequest, IEnumerable<GetAllGamesResponse>>
    {
        public async Task<IEnumerable<GetAllGamesResponse>> Handle(GetAllGamesRequest request, CancellationToken cancellationToken)
        {
            var games = await repository.ListAsync(cancellationToken);

            if (games == default || games.Count == 0)
                return [];

            var responses = new List<GetAllGamesResponse>();

            foreach (var game in games)
            {
                responses.Add(new GetAllGamesResponse
                {
                    Id = game.Id,
                    Name = game.Name,
                    Description = game.Description
                });
            }

            return responses;
        }
    }
}
