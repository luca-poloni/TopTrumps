using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications.AsNoTracking;
using MediatR;

namespace Application.UseCases.Match.Queries.GetAllMatchesByGameId
{
    internal sealed class GetAllMatchesByGameIdHandler(IReadRepository<GameAggregate> repository) : IRequestHandler<GetAllMatchesByGameIdRequest, IEnumerable<GetAllMatchesByGameIdResponse>>
    {
        public async Task<IEnumerable<GetAllMatchesByGameIdResponse>> Handle(GetAllMatchesByGameIdRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .SingleOrDefaultAsync(new GameWithAllMatchesByIdAsNoTrackingSpecification(request.GameId), cancellationToken) 
                    ?? throw new ArgumentException($"Game not found with '{request.GameId}' id to get all matches.");

            var responses = new List<GetAllMatchesByGameIdResponse>();

            foreach (var match in game.Matches)
            {
                responses.Add(new GetAllMatchesByGameIdResponse
                {
                    Id = match.Id,
                    GameId = match.GameId,
                    IsFinish = match.IsFinish
                });
            }

            return responses;
        }
    }
}
