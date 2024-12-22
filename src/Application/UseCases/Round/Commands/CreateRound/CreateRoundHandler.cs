using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsTracking;
using MediatR;

namespace Application.UseCases.Round.Commands.CreateRound
{
    internal sealed class CreateRoundHandler(IRepository<GameAggregate> repository) : IRequestHandler<CreateRoundRequest, CreateRoundResponse>
    {
        public async Task<CreateRoundResponse> Handle(CreateRoundRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithMatchByIdAsTrackingSpecification(request.MatchId), cancellationToken)
                    ?? throw new ArgumentException($"Game not found with '{request.MatchId}' match id to create round.");

            var match = game.SingleMatch();

            var round = match.AddRound();

            await repository
                .SaveChangesAsync(cancellationToken);

            return new CreateRoundResponse
            {
                Id = round.Id,
                MatchId = round.MatchId,
                WinnerPlayerId = round.WinnerPlayerId
            };
        }
    }
}
