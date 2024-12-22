using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsTracking;
using MediatR;

namespace Application.UseCases.Round.Commands.DeleteRound
{
    internal sealed class DeleteRoundHandler(IRepository<GameAggregate> repository) : IRequestHandler<DeleteRoundRequest>
    {
        public async Task Handle(DeleteRoundRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithMatchAndRoundByRoundIdAsTrackingSpecification(request.Id), cancellationToken)
                    ?? throw new ArgumentException($"Game not found with '{request.Id}' round id to delete round.");

            game.SingleMatch().RemoveSingleRound();

            await repository
                .SaveChangesAsync(cancellationToken);
        }
    }
}
