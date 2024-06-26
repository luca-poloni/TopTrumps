using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications;
using MediatR;

namespace Application.UseCases.Card.Commands.DeleteCard
{
    internal class DeleteCardHandler(IRepository<GameAggregate> repository) : IRequestHandler<DeleteCardRequest>
    {
        public async Task Handle(DeleteCardRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .FirstOrDefaultAsync(new GameByIdWithCardSpecification(request.GameId), cancellationToken) 
                    ?? throw new ArgumentException($"Game not found to delete card with id {request.Id}.");

            game.RemoveCard(request.Id);

            await repository.SaveChangesAsync(cancellationToken);
        }
    }
}
