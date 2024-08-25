using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsTracking;
using MediatR;

namespace Application.UseCases.Feature.Commands.UpdateFeature
{
    internal class UpdateFeatureHandler(IRepository<GameAggregate> repository) : IRequestHandler<UpdateFeatureRequest, UpdateFeatureResponse>
    {
        public async Task<UpdateFeatureResponse> Handle(UpdateFeatureRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithFeatureByFeatureIdAsTrackingSpecification(request.Id), cancellationToken) 
                    ?? throw new ArgumentException($"Game not found to update feature with id {request.Id}.");

            var feature = game.SingleFeature();

            feature.Update(request.Name);

            await repository
                .SaveChangesAsync(cancellationToken);

            var response = new UpdateFeatureResponse
            {
                Id = feature.Id,
                GameId = feature.GameId,
                Name = feature.Name
            };

            return response;
        }
    }
}
