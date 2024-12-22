using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsTracking;
using MediatR;

namespace Application.UseCases.Round.Actions.PlayRound
{
    internal class PlayRoundHandler(IRepository<GameAggregate> repository) : IRequestHandler<PlayRoundRequest, PlayRoundResponse>
    {
        public async Task<PlayRoundResponse> Handle(PlayRoundRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithMatchesAndPlayersAndCardsByRoundIdAndFeatureIdAsTrackingSpecification(request.Id, request.FeatureId, request.PlayerCardIds), cancellationToken)
                    ?? throw new ArgumentException($"Game not found with '{request.Id}' round id to play round.");

            var match = game.SingleMatch();
            var round = match.SingleRound();

            round.TakeCards(match.PickUpPlayerCardFromPlayers());

            var winnerPlayer = round.Winner(game.SingleFeature());

            winnerPlayer.TakePlayerCards(round.CardsToWinnerPlayer());

            var matchIsFinish = match.IsFinishAfterRound();

            await repository
                .SaveChangesAsync(cancellationToken);

            return new PlayRoundResponse
            {
                WinnerPlayerId = winnerPlayer.Id,
                MatchIsFinish = matchIsFinish
            };
        }
    }
}
