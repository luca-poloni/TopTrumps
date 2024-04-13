using Application.Common.Interfaces;
using MediatR;

namespace Application.UseCases.Card.Queries.GetAllCards
{
    internal class GetAllCardsHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllCardsRequest, IEnumerable<GetAllCardsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IEnumerable<GetAllCardsResponse>> Handle(GetAllCardsRequest request, CancellationToken cancellationToken)
        {
            var cards = await _unitOfWork.CardRepository.GetAllAsNoTrackingAsync(cancellationToken);

            if (cards == default || !cards.Any())
                return [];

            var responses = new List<GetAllCardsResponse>();

            foreach (var card in cards)
            {
                responses.Add(new GetAllCardsResponse 
                { 
                    Id = card.Id, 
                    GameId = card.GameId, 
                    Name = card.Name, 
                    IsTopTrumps = card.IsTopTrumps 
                });
            }

            return responses;
        }
    }
}
