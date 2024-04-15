using Application.Common.Interfaces;
using MediatR;

namespace Application.UseCases.Feature.Queries.GetFeatureById
{
    internal class GetFeatureByIdHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetFeatureByIdRequest, GetFeatureByIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<GetFeatureByIdResponse> Handle(GetFeatureByIdRequest request, CancellationToken cancellationToken)
        {
            var feature = await _unitOfWork.FeatureRepository.GetByIdAsNoTrackingAsync(request.Id, cancellationToken);

            if (feature == default)
                throw new FeatureNotFoundToGetByIdException();

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
