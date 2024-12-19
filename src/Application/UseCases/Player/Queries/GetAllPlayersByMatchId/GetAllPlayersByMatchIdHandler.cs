using Ardalis.SharedKernel;
using Domain.Game.Specifications.AsNoTracking;
using Domain.Game;
using MediatR;

namespace Application.UseCases.Player.Queries.GetAllPlayersByMatchId
{
    internal sealed class GetAllPlayersByMatchIdHandler(IReadRepository<GameAggregate> repository) : IRequestHandler<GetAllPlayersByMatchIdRequest, IEnumerable<GetAllPlayersByMatchIdResponse>>
    {
        public async Task<IEnumerable<GetAllPlayersByMatchIdResponse>> Handle(GetAllPlayersByMatchIdRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithAllPlayersByMatchIdAsNoTrackingSpecification(request.MatchId), cancellationToken)
                    ?? throw new ArgumentException($"Game not found with '{request.MatchId}' player id to get all player by player id.");

            var responses = new List<GetAllPlayersByMatchIdResponse>();

            foreach (var player in game.SingleMatch().Players)
            {
                responses.Add(new GetAllPlayersByMatchIdResponse
                {
                    Id = player.Id,
                    MatchId = player.MatchId,
                    Name = player.Name
                });
            }

            return responses;
        }
    }
}
