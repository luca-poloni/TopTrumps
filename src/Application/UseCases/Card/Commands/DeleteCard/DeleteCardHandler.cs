using Application.Common.Interfaces;
using MediatR;

namespace Application.UseCases.Card.Commands.DeleteCard
{
    internal class DeleteCardHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCardRequest>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(DeleteCardRequest request, CancellationToken cancellationToken)
        {
            var card = await _unitOfWork.CardRepository.GetByIdAsync(request.Id, cancellationToken);

            if (card == default)
                throw new CardNotFoundToDeleteException();

            _unitOfWork.CardRepository.Delete(card);

            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
