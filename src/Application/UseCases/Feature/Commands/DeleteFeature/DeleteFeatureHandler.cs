using Application.Common.Interfaces;
using MediatR;

namespace Application.UseCases.Feature.Commands.DeleteFeature
{
    internal class DeleteFeatureHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteFeatureRequest>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(DeleteFeatureRequest request, CancellationToken cancellationToken)
        {
            var feature = await _unitOfWork.FeatureRepository.GetByIdAsync(request.Id, cancellationToken);

            if (feature == default)
                throw new FeatureNotFoundToDeleteException();

            _unitOfWork.FeatureRepository.Delete(feature);

            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
