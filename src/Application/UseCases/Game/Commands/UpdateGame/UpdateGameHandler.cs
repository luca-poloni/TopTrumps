using Ardalis.SharedKernel;
using Domain.Game;
using MediatR;

namespace Application.UseCases.Game.Commands.UpdateGame
{
    internal sealed class UpdateGameHandler(IRepository<GameAggregate> repository) : IRequestHandler<UpdateGameRequest, UpdateGameResponse>
    {
        public async Task<UpdateGameResponse> Handle(UpdateGameRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .GetByIdAsync(request.Id, cancellationToken) ?? throw new ArgumentException("Game not found to update.");

            game.Update(request.Name, request.Description);

            await repository.UpdateAsync(game, cancellationToken);

            var response = new UpdateGameResponse
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
            };

            return response;
        }
    }
}
