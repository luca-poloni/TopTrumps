using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications;
using MediatR;

namespace Application.UseCases.Card.Queries.GetCardById
{
    public class GetCardByIdHandler(IRepository<GameAggregate> repository) : IRequestHandler<GetCardByIdRequest, GetCardByIdResponse>
    {
        public async Task<GetCardByIdResponse> Handle(GetCardByIdRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .FirstOrDefaultAsync(new GameToGetCardsSpecification(request.GameId), cancellationToken) ?? throw new ArgumentException($"Game not found to get card with id {request.Id}.");

            var card = game.CardById(request.Id);

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
