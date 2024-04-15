using Application.Common.Interfaces;
using Domain.Core.Feature;
using MediatR;

namespace Application.UseCases.Feature.Commands.CreateFeature
{
    public class CreateFeatureHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateFeatureRequest, CreateFeatureResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<CreateFeatureResponse> Handle(CreateFeatureRequest request, CancellationToken cancellationToken)
        {
            var feature = new FeatureEntity
            {
                GameId = request.GameId,
                Name = request.Name
            };

            _unitOfWork.FeatureRepository.Add(feature);

            await _unitOfWork.CommitAsync(cancellationToken);

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
