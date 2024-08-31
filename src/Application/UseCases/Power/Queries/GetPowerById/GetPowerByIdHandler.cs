using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsNoTracking;
using MediatR;

namespace Application.UseCases.Power.Queries.GetPowerById
{
    internal sealed class GetPowerByIdHandler(IReadRepository<GameAggregate> repository) : IRequestHandler<GetPowerByIdRequest, GetPowerByIdResponse>
    {
        public async Task<GetPowerByIdResponse> Handle(GetPowerByIdRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithCardByPowerIdAsNoTrackingSpecification(request.Id), cancellationToken)
                    ?? throw new ArgumentException($"Game not found with power id {request.Id} to get power.");

            var power = game.SingleCard()
                .SinglePower();

            return new GetPowerByIdResponse
            {
                Id = power.Id,
                CardId = power.CardId,
                FeatureId = power.FeatureId,
                Value = power.Value
            };
        }
    }
}
