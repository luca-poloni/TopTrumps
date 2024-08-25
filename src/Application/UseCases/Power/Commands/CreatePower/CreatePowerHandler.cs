using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsTracking;
using MediatR;

namespace Application.UseCases.Power.Commands.CreatePower
{
    internal sealed class CreatePowerHandler(IRepository<GameAggregate> repository) : IRequestHandler<CreatePowerRequest, CreatePowerResponse>
    {
        public async Task<CreatePowerResponse> Handle(CreatePowerRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithCardAndFeatureByCardAndFeatureIdAsTrackingSpecification(request.CardId, request.FeatureId), cancellationToken)
                    ?? throw new ArgumentException($"Game not found with '{request.CardId}' card id and '{request.FeatureId}' feature id to create a power.");

            var power = game.SingleCard()
                .AddPower(request.Value, game.SingleFeature());

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
