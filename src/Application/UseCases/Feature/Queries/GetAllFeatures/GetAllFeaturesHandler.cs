using Application.Common.Interfaces;
using MediatR;

namespace Application.UseCases.Feature.Queries.GetAllFeatures
{
    public class GetAllFeaturesHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllFeaturesRequest, IEnumerable<GetAllFeaturesResponse>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IEnumerable<GetAllFeaturesResponse>> Handle(GetAllFeaturesRequest request, CancellationToken cancellationToken)
        {
            var features = await _unitOfWork.FeatureRepository.GetAllAsNoTrackingAsync(cancellationToken);

            if (features == default || !features.Any())
                return [];

            var responses = new List<GetAllFeaturesResponse>();

            foreach (var feature in features)
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
