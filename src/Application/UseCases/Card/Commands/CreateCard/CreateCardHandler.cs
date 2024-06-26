using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications;
using MediatR;

namespace Application.UseCases.Card.Commands.CreateCard
{
    internal class CreateCardHandler(IRepository<GameAggregate> repository) : IRequestHandler<CreateCardRequest, CreateCardResponse>
    {
        public async Task<CreateCardResponse> Handle(CreateCardRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .FirstOrDefaultAsync(new GameByIdWithCardSpecification(request.GameId), cancellationToken) 
                    ?? throw new ArgumentException("Game not found to create card.");

            var card = game.AddCard(request.Name, request.IsTopTrumps);

            await repository.SaveChangesAsync(cancellationToken);

            var response = new CreateCardResponse
            {
                Id = card.Id,
                GameId = card.GameId,
                Name = card.Name,
                IsTopTrumps = card.IsTopTrumps
            };

            return response;
        }
    }
}
