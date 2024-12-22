using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsTracking;
using MediatR;

namespace Application.UseCases.Round.Commands.UpdateRound
{
    internal sealed class UpdateRoundHandler(IRepository<GameAggregate> repository) : IRequestHandler<UpdateRoundRequest, UpdateRoundResponse>
    {
        public async Task<UpdateRoundResponse> Handle(UpdateRoundRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithMatchAndRoundByRoundIdAsTrackingSpecification(request.Id), cancellationToken)
                    ?? throw new ArgumentException($"Game not found with '{request.Id}' round id to update round.");

            var round = game.SingleMatch().SingleRound();

            round.Update(request.WinnerPlayerId);

            await repository
                .SaveChangesAsync(cancellationToken);

            return new UpdateRoundResponse
            {
                Id = round.Id,
                MatchId = round.MatchId,
                WinnerPlayerId = round.WinnerPlayerId
            };
        }
    }
}
