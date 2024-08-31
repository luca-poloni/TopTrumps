using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsTracking;
using MediatR;

namespace Application.UseCases.Match.Commands.DeleteMatch
{
    internal sealed class DeleteMatchHandler(IRepository<GameAggregate> repository) : IRequestHandler<DeleteMatchRequest>
    {
        public async Task Handle(DeleteMatchRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithMatchByIdAsTrackingSpecification(request.Id), cancellationToken) 
                    ?? throw new ArgumentException($"Game not found to delete match with id '{request.Id}'.");

            game.RemoveSingleMatch();

            await repository
                .SaveChangesAsync(cancellationToken);
        }
    }
}
