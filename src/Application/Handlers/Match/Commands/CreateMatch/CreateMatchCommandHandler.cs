using Application.Common.Interfaces;
using Ardalis.GuardClauses;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Match.Commands.CreateMatch
{
    internal class CreateMatchCommandHandler(IApplicationDbContext applicationDbContext) : IRequestHandler<CreateMatchCommandRequest, CreateMatchCommandResponse>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;

        public async Task<CreateMatchCommandResponse> Handle(CreateMatchCommandRequest request, CancellationToken cancellationToken)
        {
            var match = await CreateMatch(request, cancellationToken);

            Guard.Against.Null(match, nameof(match), "Match cannot be created.");

            match.Play();

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            var response = new CreateMatchCommandResponse 
            { 
                Id = match.Id, 
                GameId = match.GameId, 
                IsFinish = match.IsFinish 
            };

            return response;
        }

        private async Task<MatchEntity> CreateMatch(CreateMatchCommandRequest request, CancellationToken cancellationToken)
        {
            var match = new MatchEntity { GameId = request.GameId };

            await _applicationDbContext.Matches.AddAsync(match, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return match;
        }
    }
}
