using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsTracking;
using MediatR;

namespace Application.UseCases.Card.Commands.DeleteCard
{
    internal class DeleteCardHandler(IRepository<GameAggregate> repository) : IRequestHandler<DeleteCardRequest>
    {
        public async Task Handle(DeleteCardRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithCardByCardIdAsTrackingSpecification(request.Id), cancellationToken) 
                    ?? throw new ArgumentException($"Game not found with {request.Id} card id to delete card.");

            game.RemoveSingleCard();

            await repository
                .SaveChangesAsync(cancellationToken);
        }
    }
}
