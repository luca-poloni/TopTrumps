using Application.Common.Interfaces;
using MediatR;

namespace Application.UseCases.Card.Queries.GetCardById
{
    public class GetCardByIdHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetCardByIdRequest, GetCardByIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<GetCardByIdResponse> Handle(GetCardByIdRequest request, CancellationToken cancellationToken)
        {
            var card = await _unitOfWork.CardRepository.GetByIdAsNoTrackingAsync(request.Id, cancellationToken);

            if (card == default)
                throw new CardNotFoundToGetByIdException();

            var response = new GetCardByIdResponse
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
