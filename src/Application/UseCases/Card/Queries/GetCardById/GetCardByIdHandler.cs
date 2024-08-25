using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsNoTracking;
using MediatR;

namespace Application.UseCases.Card.Queries.GetCardById
{
    public class GetCardByIdHandler(IReadRepository<GameAggregate> repository) : IRequestHandler<GetCardByIdRequest, GetCardByIdResponse>
    {
        public async Task<GetCardByIdResponse> Handle(GetCardByIdRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithCardByCardIdAsNoTrackingSpecification(request.Id), cancellationToken) 
                    ?? throw new ArgumentException($"Game not found to get card with id {request.Id}.");

            var card = game.SingleCard();

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
