using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsNoTracking;
using MediatR;

namespace Application.UseCases.Player.Queries.GetPlayerById
{
    internal sealed class GetPlayerByIdHandler(IReadRepository<GameAggregate> repository) : IRequestHandler<GetPlayerByIdRequest, GetPlayerByIdResponse>
    {
        public async Task<GetPlayerByIdResponse> Handle(GetPlayerByIdRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithMatchAndPlayerByPlayerIdAsNoTrackingSpecification(request.Id), cancellationToken)
                    ?? throw new ArgumentException($"Game not found with '{request.Id}' player id to get player by id.");

            var player = game.SingleMatch().SinglePlayer();

            return new GetPlayerByIdResponse
            {
                Id = player.Id,
                MatchId = player.MatchId,
                Name = player.Name
            };
        }
    }
}
