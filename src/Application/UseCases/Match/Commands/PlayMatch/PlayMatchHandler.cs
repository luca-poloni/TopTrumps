using Application.Common.Interfaces;
using Domain.Repositores;
using MediatR;

namespace Application.UseCases.Match.Commands
{
    internal class PlayMatchHandler(IApplicationDbContext context, IMatchRepository matchRepository) : IRequestHandler<PlayMatchRequest, PlayMatchResponse>
    {
        private readonly IMatchRepository _matchRepository = matchRepository;
        private readonly IApplicationDbContext _context = context;

        public async Task<PlayMatchResponse> Handle(PlayMatchRequest request, CancellationToken cancellationToken)
        {
            var match = await _matchRepository.GetById(request.Id, cancellationToken);

            match.Play();

            await _context.SaveChangesAsync(cancellationToken);

            var response = new PlayMatchResponse
            {
                Id = match.Id,
                GameId = match.GameId,
                IsFinish = match.IsFinish
            };

            return response;
        }
    }
}
