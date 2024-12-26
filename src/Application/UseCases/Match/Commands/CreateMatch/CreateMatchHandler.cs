using Ardalis.SharedKernel;
using Domain.Game;
using MediatR;

namespace Application.UseCases.Match.Commands.CreateMatch
{
    internal sealed class CreateMatchHandler(IRepository<GameAggregate> repository) : IRequestHandler<CreateMatchRequest, CreateMatchResponse>
    {
        public async Task<CreateMatchResponse> Handle(CreateMatchRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .GetByIdAsync(request.GameId, cancellationToken) 
                    ?? throw new ArgumentException($"Game not found with '{request.GameId}' id to create match.");

            var match = game.AddMatch();

            await repository
                .SaveChangesAsync(cancellationToken);

            return new CreateMatchResponse
            {
                Id = match.Id,
                GameId = match.GameId,
                WinnerPlayerId = match.WinnerPlayerId
            };
        }
    }
}
