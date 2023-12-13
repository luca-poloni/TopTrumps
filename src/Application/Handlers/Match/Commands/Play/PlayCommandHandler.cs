using Application.Common.Interfaces;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Match.Commands.Play
{
    internal class PlayCommandHandler(IApplicationDbContext applicationDbContext) : IRequestHandler<PlayCommandRequest, Result>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;

        public async Task<Result> Handle(PlayCommandRequest request, CancellationToken cancellationToken)
        {
            var match = await _applicationDbContext.Matches.SingleOrDefaultAsync(match => match.Id == request.MatchId, cancellationToken);

            if (match == default)
                return Result.Fail("Match cannot be found.");

            match.Play();

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
