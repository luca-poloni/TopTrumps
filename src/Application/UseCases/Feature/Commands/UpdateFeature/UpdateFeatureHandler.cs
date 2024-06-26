using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications;
using MediatR;

namespace Application.UseCases.Feature.Commands.UpdateFeature
{
    internal class UpdateFeatureHandler(IRepository<GameAggregate> repository) : IRequestHandler<UpdateFeatureRequest, UpdateFeatureResponse>
    {
        public async Task<UpdateFeatureResponse> Handle(UpdateFeatureRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .FirstOrDefaultAsync(new GameByIdWithFeatureSpecification(request.GameId), cancellationToken) 
                    ?? throw new ArgumentException($"Game not found to update feature with id {request.Id}.");

            var feature = game.FeatureById(request.Id);

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
