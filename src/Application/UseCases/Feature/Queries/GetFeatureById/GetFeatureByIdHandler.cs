using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications;
using MediatR;

namespace Application.UseCases.Feature.Queries.GetFeatureById
{
    internal class GetFeatureByIdHandler(IRepository<GameAggregate> repository) : IRequestHandler<GetFeatureByIdRequest, GetFeatureByIdResponse>
    {
        public async Task<GetFeatureByIdResponse> Handle(GetFeatureByIdRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .FirstOrDefaultAsync(new GameByIdWithFeatureSpecification(request.GameId), cancellationToken) 
                    ?? throw new ArgumentException($"Game not found to get feature by id {request.Id}.");

            var feature = game.FeatureById(request.Id);

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
