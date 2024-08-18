using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications;
using MediatR;

namespace Application.UseCases.Power.Queries.GetAllPowersByCardId
{
    internal sealed class GetAllPowersByCardIdHandler(IRepository<GameAggregate> repository) : IRequestHandler<GetAllPowersByCardIdRequest, IEnumerable<GetAllPowersByCardIdResponse>>
    {
        public async Task<IEnumerable<GetAllPowersByCardIdResponse>> Handle(GetAllPowersByCardIdRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .FirstOrDefaultAsync(new GameToGetAllPowersReadOnlySpecification(request.CardId), cancellationToken)
                    ?? throw new ArgumentException($"Game not found with '{request.CardId}' card id to get all powers.");

            var card = game.SingleCard();

            if (card.HasNoPowers())
                return [];

            var responses = new List<GetAllPowersByCardIdResponse>();

            foreach (var power in card.Powers)
            {
                responses.Add(new GetAllPowersByCardIdResponse
                {
                    Id = power.Id,
                    CardId = power.CardId,
                    FeatureId = power.FeatureId,
                    Value = power.Value
                });
            }

            return responses;
        }
    }
}
