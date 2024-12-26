using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsTracking;
using MediatR;

namespace Application.UseCases.Match.Commands.UpdateMatch
{
    internal sealed class UpdateMatchHandler(IRepository<GameAggregate> repository) : IRequestHandler<UpdateMatchRequest, UpdateMatchResponse>
    {
        public async Task<UpdateMatchResponse> Handle(UpdateMatchRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithMatchByIdAsTrackingSpecification(request.Id), cancellationToken) 
                    ?? throw new ArgumentException($"Game not found to update match with id '{request.Id}'.");

            var match = game.SingleMatch();

            match.Update(request.WinnerPlayerId);

            await repository
                .SaveChangesAsync(cancellationToken);

            return new UpdateMatchResponse
            {
                Id = match.Id,
                GameId = match.GameId,
                WinnerPlayerId = match.WinnerPlayerId
            };
        }
    }
}
