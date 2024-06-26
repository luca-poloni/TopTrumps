using Ardalis.SharedKernel;
using Domain.Game;
using MediatR;

namespace Application.UseCases.Game.Commands.CreateGame
{
    internal sealed class CreateGameHandler(IRepository<GameAggregate> repository) : IRequestHandler<CreateGameRequest, CreateGameResponse>
    {
        public async Task<CreateGameResponse> Handle(CreateGameRequest request, CancellationToken cancellationToken)
        {
            var game = new GameAggregate
            {
                Name = request.Name,
                Description = request.Description
            };

            await repository.AddAsync(game, cancellationToken);

            var response = new CreateGameResponse
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
            };

            return response;
        }
    }
}
