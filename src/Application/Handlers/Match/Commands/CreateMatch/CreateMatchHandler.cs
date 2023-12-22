using Application.Common.Interfaces;
using Ardalis.GuardClauses;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Match.Commands.CreateMatch
{
    internal class CreateMatchHandler(IApplicationDbContext applicationDbContext) : IRequestHandler<CreateMatchRequest, CreateMatchResponse>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;

        public async Task<CreateMatchResponse> Handle(CreateMatchRequest request, CancellationToken cancellationToken)
        {
            var match = new MatchEntity(request.GameId);
            await _applicationDbContext.Matches.AddAsync(match, cancellationToken);
            var affectedRows = await _applicationDbContext.SaveChangesAsync(cancellationToken);

            Guard.Against.NegativeOrZero(affectedRows, nameof(match), "Match cannot be created.");

            var response = new CreateMatchResponse 
            {
                Id = match.Id, 
                GameId = match.GameId, 
                IsFinish = match.IsFinish
            };

            return response;
        }
    }
}
