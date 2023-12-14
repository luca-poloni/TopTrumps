using Application.Common.Interfaces;
using Ardalis.GuardClauses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Match.Commands.MoveMatch
{
    internal class MoveMatchHandler(IApplicationDbContext applicationDbContext) : IRequestHandler<MoveMatchRequest, MoveMatchResponse>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;

        public async Task<MoveMatchResponse> Handle(MoveMatchRequest request, CancellationToken cancellationToken)
        {
            var match = await _applicationDbContext.Matches.SingleOrDefaultAsync(match => match.Id == request.Id, cancellationToken);

            Guard.Against.Null(match, nameof(match), "Match cannot be found.");

            match.Move(request.FeatureName);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            var response = new MoveMatchResponse
            {
                Id = match.Id,
                GameId = match.GameId,
                IsFinish = match.IsFinish
            };

            return response;
        }
    }
}
