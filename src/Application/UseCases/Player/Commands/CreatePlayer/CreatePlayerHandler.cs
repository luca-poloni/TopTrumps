using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsTracking;
using MediatR;

namespace Application.UseCases.Player.Commands.CreatePlayer
{
    internal sealed class CreatePlayerHandler(IRepository<GameAggregate> repository) : IRequestHandler<CreatePlayerRequest, CreatePlayerResponse>
    {
        public async Task<CreatePlayerResponse> Handle(CreatePlayerRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithMatchByIdAsTrackingSpecification(request.MatchId), cancellationToken)
                    ?? throw new ArgumentException($"Game not found with '{request.MatchId}' match id to create player.");

            var match = game.SingleMatch();

            var player = match.AddPlayer(request.Name);

            await repository
                .SaveChangesAsync(cancellationToken);

            return new CreatePlayerResponse
            {
                Id = player.Id,
                MatchId = player.MatchId,
                Name = player.Name
            };
        }
    }
}
