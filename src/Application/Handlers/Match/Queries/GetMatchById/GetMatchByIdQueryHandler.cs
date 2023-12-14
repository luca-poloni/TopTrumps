using Application.Common.Interfaces;
using Ardalis.GuardClauses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Match.Queries.GetMatchById
{
    internal class GetMatchByIdQueryHandler(IApplicationDbContext applicationDbContext) : IRequestHandler<GetMatchByIdQueryRequest, GetMatchByIdQueryResponse>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;

        public async Task<GetMatchByIdQueryResponse> Handle(GetMatchByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var match = await _applicationDbContext.Matches.SingleOrDefaultAsync(match => match.Id == request.Id, cancellationToken);

            Guard.Against.Null(match, nameof(match), "Match cannot be found.");

            var response = new GetMatchByIdQueryResponse
            {
                Id = match.Id,
                GameId = match.GameId,
                IsFinish = match.IsFinish
            };

            return response;
        }
    }
}
