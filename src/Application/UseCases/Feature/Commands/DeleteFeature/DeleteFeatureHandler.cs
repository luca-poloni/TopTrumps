using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsTracking;
using MediatR;

namespace Application.UseCases.Feature.Commands.DeleteFeature
{
    internal class DeleteFeatureHandler(IRepository<GameAggregate> repository) : IRequestHandler<DeleteFeatureRequest>
    {
        public async Task Handle(DeleteFeatureRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithFeatureByFeatureIdAsTrackingSpecification(request.Id), cancellationToken) 
                    ?? throw new ArgumentException($"Game not found to delete feature with id {request.Id}.");

            game.RemoveSingleFeature();

            await repository
                .SaveChangesAsync(cancellationToken);
        }
    }
}
