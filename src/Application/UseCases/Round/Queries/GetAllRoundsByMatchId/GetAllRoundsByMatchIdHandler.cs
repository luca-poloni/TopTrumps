using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsNoTracking;
using MediatR;

namespace Application.UseCases.Round.Queries.GetAllRoundsByMatchId
{
    internal sealed class GetAllRoundsByMatchIdHandler(IReadRepository<GameAggregate> repository) : IRequestHandler<GetAllRoundsByMatchIdRequest, IEnumerable<GetAllRoundsByMatchIdResponse>>
    {
        public async Task<IEnumerable<GetAllRoundsByMatchIdResponse>> Handle(GetAllRoundsByMatchIdRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithAllRoundsByMatchIdAsNoTrackingSpecification(request.MatchId), cancellationToken)
                    ?? throw new ArgumentException($"Game not found with '{request.MatchId}' match id to get all rounds by match id.");

            var responses = new List<GetAllRoundsByMatchIdResponse>();

            foreach (var round in game.SingleMatch().Rounds)
            {
                responses.Add(new GetAllRoundsByMatchIdResponse
                {
                    Id = round.Id,
                    MatchId = round.MatchId,
                    WinnerPlayerId = round.WinnerPlayerId
                });
            }

            return responses;
        }
    }
}
