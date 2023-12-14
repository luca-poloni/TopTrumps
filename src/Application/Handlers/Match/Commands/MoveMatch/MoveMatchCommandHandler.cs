using Application.Common.Interfaces;
using Ardalis.GuardClauses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Match.Commands.MoveMatch
{
    internal class MoveMatchCommandHandler(IApplicationDbContext applicationDbContext) : IRequestHandler<MoveMatchCommandRequest, MoveMatchCommandResponse>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;

        public async Task<MoveMatchCommandResponse> Handle(MoveMatchCommandRequest request, CancellationToken cancellationToken)
        {
            var match = await _applicationDbContext.Matches.SingleOrDefaultAsync(match => match.Id == request.Id, cancellationToken);

            Guard.Against.Null(match, nameof(match), "Match cannot be found.");

            match.Move(request.FeatureName);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            var response = new MoveMatchCommandResponse
            {
                Id = match.Id,
                GameId = match.GameId,
                IsFinish = match.IsFinish
            };

            return response;
        }
    }
}
