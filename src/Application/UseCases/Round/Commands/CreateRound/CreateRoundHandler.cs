using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Round.Commands
{
    internal class CreateRoundHandler(IApplicationDbContext context) : IRequestHandler<CreateRoundRequest, CreateRoundResponse>
    {
        private readonly IApplicationDbContext _context = context;

        public async Task<CreateRoundResponse> Handle(CreateRoundRequest request, CancellationToken cancellationToken)
        {
            var round = new RoundEntity(request.MatchId);

            await _context.Rounds.AddAsync(round, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var response = new CreateRoundResponse
            {
                Id = round.Id,
                MatchId = round.MatchId,
                WinnerPlayerId = round.WinnerPlayerId
            };

            return response;
        }
    }
}
