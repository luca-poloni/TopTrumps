using Application.Common.Interfaces;
using Domain.Core.Card;
using MediatR;

namespace Application.UseCases.Card.Commands.CreateCard
{
    internal class CreateCardHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateCardRequest, CreateCardResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<CreateCardResponse> Handle(CreateCardRequest request, CancellationToken cancellationToken)
        {
            var card = new CardEntity
            {
                GameId = request.GameId,
                Name = request.Name,
                IsTopTrumps = request.IsTopTrumps
            };

            _unitOfWork.CardRepository.Add(card);

            await _unitOfWork.CommitAsync(cancellationToken);

            var response = new CreateCardResponse
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
