using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications;
using MediatR;

namespace Application.UseCases.Power.Commands.CreatePower
{
    internal sealed class CreatePowerHandler(IRepository<GameAggregate> repository) : IRequestHandler<CreatePowerRequest, CreatePowerResponse>
    {
        public async Task<CreatePowerResponse> Handle(CreatePowerRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .FirstOrDefaultAsync(new GameToCreatePowerSpecification(request.CardId), cancellationToken)
                    ?? throw new ArgumentException($"Game not found with '{request.CardId}' card id to create a new power.");

            var power = game
                .SingleCard()
                    .AddPower(request.Value, game.FeatureById(request.FeatureId));

            await repository
                .SaveChangesAsync(cancellationToken);

            return new CreatePowerResponse 
            {
                Id = power.Id,
                CardId = power.CardId,
                FeatureId = power.FeatureId,
                Value = power.Value
            };
        }
    }
}
