using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsNoTracking;
using MediatR;

namespace Application.UseCases.Round.Queries.GetRoundById
{
    internal sealed class GetRoundByIdHandler(IReadRepository<GameAggregate> repository) : IRequestHandler<GetRoundByIdRequest, GetRoundByIdResponse>
    {
        public async Task<GetRoundByIdResponse> Handle(GetRoundByIdRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithMatchAndRoundByRoundIdAsNoTrackingSpecification(request.Id), cancellationToken)
                    ?? throw new ArgumentException($"Game not found with round id {request.Id} to get round by id.");

            var round = game.SingleMatch()
                .SingleRound();

            return new GetRoundByIdResponse
            {
                Id = round.Id,
                MatchId = round.MatchId,
                WinnerPlayerId = round.WinnerPlayerId
            };
        }
    }
}
