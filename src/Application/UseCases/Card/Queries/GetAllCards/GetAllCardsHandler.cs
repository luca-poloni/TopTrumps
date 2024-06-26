using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications;
using MediatR;

namespace Application.UseCases.Card.Queries.GetAllCards
{
    internal class GetAllCardsHandler(IRepository<GameAggregate> repository) : IRequestHandler<GetAllCardsRequest, IEnumerable<GetAllCardsResponse>>
    {
        public async Task<IEnumerable<GetAllCardsResponse>> Handle(GetAllCardsRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .FirstOrDefaultAsync(new GameByIdWithCardSpecification(request.GameId), cancellationToken) ?? throw new ArgumentException($"Game not found to get all cards.");

            var responses = new List<GetAllCardsResponse>();

            foreach (var card in game.Cards)
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
