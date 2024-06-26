using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications;
using MediatR;

namespace Application.UseCases.Feature.Commands.CreateFeature
{
    internal sealed class CreateFeatureHandler(IRepository<GameAggregate> repository) : IRequestHandler<CreateFeatureRequest, CreateFeatureResponse>
    {
        public async Task<CreateFeatureResponse> Handle(CreateFeatureRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .FirstOrDefaultAsync(new GameByIdWithFeatureSpecification(request.GameId), cancellationToken) 
                    ?? throw new ArgumentException("Game not found to create feature.");

            var feature = game.AddFeature(request.Name);

            await repository.SaveChangesAsync(cancellationToken);

            var response = new CreateFeatureResponse
            {
                Id = feature.Id,
                GameId = feature.GameId,
                Name = feature.Name
            };

            return response;
        }
    }
}
