using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsTracking;
using MediatR;

namespace Application.UseCases.Player.Commands.UpdatePlayer
{
    internal sealed class UpdatePlayerHandler(IRepository<GameAggregate> repository) : IRequestHandler<UpdatePlayerRequest, UpdatePlayerResponse>
    {
        public async Task<UpdatePlayerResponse> Handle(UpdatePlayerRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithMatchAndPlayerByPlayerIdAsTrackingSpecification(request.Id), cancellationToken)
                    ?? throw new ArgumentException($"Game not found with '{request.Id}' player id to update player.");

            var player = game.SingleMatch().SinglePlayer();

            player.Update(request.Name);

            await repository
                .SaveChangesAsync(cancellationToken);

            return new UpdatePlayerResponse
            {
                Id = player.Id,
                MatchId = player.MatchId,
                Name = player.Name
            };
        }
    }
}
