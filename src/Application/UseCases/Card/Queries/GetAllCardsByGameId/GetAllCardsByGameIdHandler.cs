using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsNoTracking;
using MediatR;

namespace Application.UseCases.Card.Queries.GetAllCardsByGameId
{
    internal class GetAllCardsByGameIdHandler(IReadRepository<GameAggregate> repository) : IRequestHandler<GetAllCardsByGameIdRequest, IEnumerable<GetAllCardsByGameIdResponse>>
    {
        public async Task<IEnumerable<GetAllCardsByGameIdResponse>> Handle(GetAllCardsByGameIdRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithAllCardsByIdAsNoTrackingSpecification(request.GameId), cancellationToken) 
                    ?? throw new ArgumentException($"Game not found with '{request.GameId}' id to get all cards.");

            var responses = new List<GetAllCardsByGameIdResponse>();

            foreach (var card in game.Cards)
            {
                responses.Add(new GetAllCardsByGameIdResponse 
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
