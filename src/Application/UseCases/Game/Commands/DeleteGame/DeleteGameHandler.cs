using Ardalis.SharedKernel;
using Domain.Game;
using MediatR;

namespace Application.UseCases.Game.Commands.DeleteGame
{
    internal sealed class DeleteGameHandler(IRepository<GameAggregate> repository) : IRequestHandler<DeleteGameRequest>
    {
        public async Task Handle(DeleteGameRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .GetByIdAsync(request.Id, cancellationToken) ?? throw new ArgumentException("Game not found to delete");

            await repository.DeleteAsync(game, cancellationToken);
        }
    }
}
