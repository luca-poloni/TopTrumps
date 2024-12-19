using Ardalis.Specification;

namespace Domain.Game.Specifications.AsNoTracking
{
    public class GameWithAllPlayersByMatchIdAsNoTrackingSpecification : SingleResultSpecification<GameAggregate>
    {
        public GameWithAllPlayersByMatchIdAsNoTrackingSpecification(Guid matchId)
        {
            base.Query
                .Include(game => game.Matches.Where(match => match.Id == matchId))
                .ThenInclude(match => match.Players)
                .Where(game => game.Matches.Any(match => match.Id == matchId))
                .AsNoTracking();
        }
    }
}
