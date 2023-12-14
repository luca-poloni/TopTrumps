using Application.Common.Interfaces;
using Ardalis.GuardClauses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Match.Commands.PlayMatch
{
    internal class PlayMatchCommandHandler(IApplicationDbContext applicationDbContext) : IRequestHandler<PlayMatchCommandRequest, PlayMatchCommandResponse>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;

        public async Task<PlayMatchCommandResponse> Handle(PlayMatchCommandRequest request, CancellationToken cancellationToken)
        {
            var match = await _applicationDbContext.Matches.SingleOrDefaultAsync(match => match.Id == request.Id, cancellationToken);

            Guard.Against.Null(match, nameof(match), "Match cannot be found.");

            match.Play();

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            var response = new PlayMatchCommandResponse
            {
                Id = match.Id,
                GameId = match.GameId,
                IsFinish = match.IsFinish
            };

            return response;
        }
    }
}
