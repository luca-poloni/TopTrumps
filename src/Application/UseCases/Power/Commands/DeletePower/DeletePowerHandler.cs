using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications;
using MediatR;

namespace Application.UseCases.Power.Commands.DeletePower
{
    public class DeletePowerHandler(IRepository<GameAggregate> repository) : IRequestHandler<DeletePowerRequest>
    {
        public async Task Handle(DeletePowerRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .FirstOrDefaultAsync(new GameToGetPowerSpecification(request.Id), cancellationToken)
                    ?? throw new ArgumentException($"Game not found with power id {request.Id} to delete power.");

            game.SingleCard()
                    .RemoveSinglePower();

            await repository
                .SaveChangesAsync(cancellationToken);
        }
    }
}
