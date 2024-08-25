using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsNoTracking;
using MediatR;

namespace Application.UseCases.Feature.Queries.GetFeatureById
{
    internal class GetFeatureByIdHandler(IReadRepository<GameAggregate> repository) : IRequestHandler<GetFeatureByIdRequest, GetFeatureByIdResponse>
    {
        public async Task<GetFeatureByIdResponse> Handle(GetFeatureByIdRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithFeatureByFeatureIdAsNoTrackingSpecification(request.Id), cancellationToken) 
                    ?? throw new ArgumentException($"Game not found to get feature by id {request.Id}.");

            var feature = game.SingleFeature();

            var response = new GetFeatureByIdResponse 
            { 
                Id = feature.Id, 
                GameId = feature.GameId, 
                Name = feature.Name 
            };

            return response;
        }
    }
}
