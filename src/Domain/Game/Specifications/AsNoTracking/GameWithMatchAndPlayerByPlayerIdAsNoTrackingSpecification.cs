using Ardalis.Specification;

namespace Domain.Game.Specifications.AsNoTracking
{
    public class GameWithMatchAndPlayerByPlayerIdAsNoTrackingSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameWithMatchAndPlayerByPlayerIdAsNoTrackingSpecification(Guid playerId)
        {
            Query
                .Include(game => game.Matches.Where(match => match.Players.Any(player => player.Id == playerId)))
                .ThenInclude(match => match.Players.Where(player => player.Id == playerId))
                .Where(game => game.Matches.Any(match => match.Players.Any(player => player.Id == playerId)))
                .AsNoTracking();
        }
    }
}
