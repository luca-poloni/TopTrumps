using Application.Common.Interfaces;
using MediatR;

namespace Application.UseCases.Feature.Commands.UpdateFeature
{
    internal class UpdateFeatureHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateFeatureRequest, UpdateFeatureResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<UpdateFeatureResponse> Handle(UpdateFeatureRequest request, CancellationToken cancellationToken)
        {
            var feature = await _unitOfWork.FeatureRepository.GetByIdAsync(request.Id, cancellationToken);

            if (feature == default)
                throw new FeatureNotFoundToUpdateException();

            feature.Update(request.Name);

            _unitOfWork.FeatureRepository.Update(feature);

            await _unitOfWork.CommitAsync(cancellationToken);

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
