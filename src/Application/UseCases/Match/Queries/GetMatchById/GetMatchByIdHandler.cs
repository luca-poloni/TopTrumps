using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsNoTracking;
using MediatR;

namespace Application.UseCases.Match.Queries.GetMatchById
{
    internal sealed class GetMatchByIdHandler(IRepository<GameAggregate> repository) : IRequestHandler<GetMatchByIdRequest, GetMatchByIdResponse>
    {
        public async Task<GetMatchByIdResponse> Handle(GetMatchByIdRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithMatchByIdAsNoTrackingSpecification(request.Id), cancellationToken) 
                    ?? throw new ArgumentException($"Game not found to get match with id '{request.Id}'.");

            var match = game.SingleMatch();

            return new GetMatchByIdResponse
            {
                Id = match.Id,
                GameId = match.GameId,
                WinnerPlayerId = match.WinnerPlayerId
            };
        }
    }
}
