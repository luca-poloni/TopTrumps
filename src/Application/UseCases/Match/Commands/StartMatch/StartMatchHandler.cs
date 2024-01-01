using Application.Common.Interfaces;
using Domain.Repositores;
using MediatR;

namespace Application.UseCases.Match.Commands
{
    internal class StartMatchHandler(IMatchRepository matchRepository, IApplicationDbContext context) : IRequestHandler<StartMatchRequest, StartMatchResponse>
    {
        private readonly IMatchRepository _matchRepository = matchRepository;
        private readonly IApplicationDbContext _context = context;

        public async Task<StartMatchResponse> Handle(StartMatchRequest request, CancellationToken cancellationToken)
        {
            var match = await _matchRepository.GetById(request.Id, cancellationToken);

            match.Start();

            await _context.SaveChangesAsync(cancellationToken);

            var response = new StartMatchResponse
            {
                Id = match.Id,
                GameId = match.GameId,
                IsFinish = match.IsFinish
            };

            return response;
        }
    }
}
