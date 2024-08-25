using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsTracking;
using MediatR;

namespace Application.UseCases.Power.Commands.UpdatePower
{
    internal sealed class UpdatePowerHandler(IRepository<GameAggregate> repository) : IRequestHandler<UpdatePowerRequest, UpdatePowerResponse>
    {
        public async Task<UpdatePowerResponse> Handle(UpdatePowerRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithCardByPowerIdAsTrackingSpecification(request.Id), cancellationToken)
                    ?? throw new ArgumentException($"Game not found with power id {request.Id} to update power.");

            var power = game.SingleCard()
                .SinglePower();
                        
            power.Update(request.Value);

            await repository
                .SaveChangesAsync(cancellationToken);

            return new UpdatePowerResponse 
            { 
                Id = power.Id, 
                CardId = power.CardId,
                FeatureId = power.FeatureId,
                Value = power.Value 
            };
        }
    }
}
