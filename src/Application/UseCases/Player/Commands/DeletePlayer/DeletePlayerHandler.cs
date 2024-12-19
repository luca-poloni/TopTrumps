using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsTracking;
using MediatR;

namespace Application.UseCases.Player.Commands.DeletePlayer
{
    internal sealed class DeletePlayerHandler(IRepository<GameAggregate> repository) : IRequestHandler<DeletePlayerRequest>
    {
        public async Task Handle(DeletePlayerRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithMatchAndPlayerByPlayerIdAsTrackingSpecification(request.Id), cancellationToken)
                    ?? throw new ArgumentException($"Game not found with '{request.Id}' player id to delete player.");

            game.SingleMatch().RemoveSinglePlayer();

            await repository
                .SaveChangesAsync(cancellationToken);
        }
    }
}
