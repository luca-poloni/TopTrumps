using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications;
using MediatR;

namespace Application.UseCases.Feature.Queries.GetAllFeatures
{
    public class GetAllFeaturesHandler(IRepository<GameAggregate> repository) : IRequestHandler<GetAllFeaturesRequest, IEnumerable<GetAllFeaturesResponse>>
    {
        public async Task<IEnumerable<GetAllFeaturesResponse>> Handle(GetAllFeaturesRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .FirstOrDefaultAsync(new GameByIdWithFeatureSpecification(request.GameId), cancellationToken) 
                    ?? throw new ArgumentException("Game not found to get all features.");

            var responses = new List<GetAllFeaturesResponse>();

            foreach (var feature in game.Features)
            {
                responses.Add(new GetAllFeaturesResponse 
                { 
                    Id = feature.Id, 
                    GameId = feature.GameId, 
                    Name = feature.Name 
                });
            }

            return responses;
        }
    }
}
