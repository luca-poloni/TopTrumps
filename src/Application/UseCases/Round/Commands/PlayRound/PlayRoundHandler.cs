using Application.Common.Interfaces;
using Domain.Repositores;
using MediatR;

namespace Application.UseCases.Round.Commands
{
    internal class PlayRoundHandler(IRoundRepository roundRepository, IApplicationDbContext context) : IRequestHandler<PlayRoundRequest, PlayRoundResponse>
    {
        private readonly IRoundRepository _roundRepository = roundRepository;
        private readonly IApplicationDbContext _context = context;

        public async Task<PlayRoundResponse> Handle(PlayRoundRequest request, CancellationToken cancellationToken)
        {
            var round = await _roundRepository.GetById(request.Id, cancellationToken);

            round.Play(request.FeatureName);

            await _context.SaveChangesAsync(cancellationToken);

            var response = new PlayRoundResponse 
            { 
                Id = round.Id, 
                MatchId = round.MatchId,
                WinnerPlayerId = round.WinnerPlayerId 
            };

            return response;
        }
    }
}
