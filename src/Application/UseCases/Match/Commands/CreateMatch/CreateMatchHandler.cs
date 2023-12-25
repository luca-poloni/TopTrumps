using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Match.Commands
{
    internal class CreateMatchHandler(IApplicationDbContext context) : IRequestHandler<CreateMatchRequest, CreateMatchResponse>
    {
        private readonly IApplicationDbContext _context = context;

        public async Task<CreateMatchResponse> Handle(CreateMatchRequest request, CancellationToken cancellationToken)
        {
            var match = new MatchEntity(request.GameId);

            await _context.Matches.AddAsync(match, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

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
