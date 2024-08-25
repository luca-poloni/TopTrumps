using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsNoTracking;
using MediatR;

namespace Application.UseCases.Feature.Queries.GetAllFeaturesByGameId
{
    public class GetAllFeaturesByGameIdHandler(IReadRepository<GameAggregate> repository) : IRequestHandler<GetAllFeaturesByGameIdRequest, IEnumerable<GetAllFeaturesByGameIdResponse>>
    {
        public async Task<IEnumerable<GetAllFeaturesByGameIdResponse>> Handle(GetAllFeaturesByGameIdRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithAllFeaturesByIdAsNoTrackingSpecification(request.GameId), cancellationToken) 
                    ?? throw new ArgumentException($"Game not found to get all features with id {request.GameId}.");

            var responses = new List<GetAllFeaturesByGameIdResponse>();

            foreach (var feature in game.Features)
            {
                responses.Add(new GetAllFeaturesByGameIdResponse 
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
