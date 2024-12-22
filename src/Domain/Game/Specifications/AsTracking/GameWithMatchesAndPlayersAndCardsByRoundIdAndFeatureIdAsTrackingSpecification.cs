using Ardalis.Specification;

namespace Domain.Game.Specifications.AsTracking
{
    public class GameWithMatchesAndPlayersAndCardsByRoundIdAndFeatureIdAsTrackingSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameWithMatchesAndPlayersAndCardsByRoundIdAndFeatureIdAsTrackingSpecification(Guid roundId, Guid featureId, IEnumerable<Guid> playerCardIds)
        {
            Query
                .Include(game => game.Matches.Where(match => match.Rounds.Any(round => round.Id == roundId)))
                .ThenInclude(match => match.Rounds)
                .Include(game => game.Matches.Where(match => match.Rounds.Any(round => round.Id == roundId)))
                .ThenInclude(match => match.Players)
                .ThenInclude(player => player.PlayerCards.Where(playerCard => playerCardIds.Contains(playerCard.Id)))
                .ThenInclude(playerCard => playerCard.MatchCard)
                .ThenInclude(matchCard => matchCard.Card)
                .ThenInclude(card => card.Powers)
                .ThenInclude(power => power.Feature)
                .Include(game => game.Features.Where(feature => feature.Id == featureId))
                .Where(game => game.Matches.Any(match => match.Rounds.Any(round => round.Id == roundId)));
        }
    }

}
