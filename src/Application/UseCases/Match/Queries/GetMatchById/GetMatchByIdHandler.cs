using Application.Common.Interfaces;
using Ardalis.GuardClauses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Match.Queries.GetMatchById
{
    internal class GetMatchByIdHandler(IApplicationDbContext applicationDbContext) : IRequestHandler<GetMatchByIdRequest, GetMatchByIdResponse>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;

        public async Task<GetMatchByIdResponse> Handle(GetMatchByIdRequest request, CancellationToken cancellationToken)
        {
            var match = await _applicationDbContext.Matches.SingleOrDefaultAsync(match => match.Id == request.Id, cancellationToken);

            Guard.Against.Null(match, nameof(match), "Match cannot be found.");

            var response = new GetMatchByIdResponse
            {
                Id = match.Id,
                GameId = match.GameId,
                IsFinish = match.IsFinish
            };

            return response;
        }
    }
}
