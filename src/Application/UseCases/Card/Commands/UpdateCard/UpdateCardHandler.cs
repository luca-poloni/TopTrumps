using Application.Common.Interfaces;
using MediatR;

namespace Application.UseCases.Card.Commands.UpdateCard
{
    internal class UpdateCardHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateCardRequest, UpdateCardResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<UpdateCardResponse> Handle(UpdateCardRequest request, CancellationToken cancellationToken)
        {
            var card = await _unitOfWork.CardRepository.GetByIdAsync(request.Id, cancellationToken);

            if (card == default)
                throw new ArgumentException("Card not found to update.");

            card.Update(request.Name, request.IsTopTrumps);

            _unitOfWork.CardRepository.Update(card);

            await _unitOfWork.CommitAsync(cancellationToken);

            var response = new UpdateCardResponse
            {
                Id = card.Id,
                GameId = card.GameId,
                Name = card.Name,
                IsTopTrumps = card.IsTopTrumps
            };

            return response;
        }
    }
}
