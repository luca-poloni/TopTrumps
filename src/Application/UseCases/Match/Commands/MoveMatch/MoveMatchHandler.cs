using Application.Common.Interfaces;
using Domain.Repositores;
using MediatR;

namespace Application.UseCases.Match.Commands
{
    internal class MoveMatchHandler(IApplicationDbContext context, IMatchRepository matchRepository) : IRequestHandler<MoveMatchRequest, MoveMatchResponse>
    {
        private readonly IMatchRepository _matchRepository = matchRepository;
        private readonly IApplicationDbContext _context = context;

        public async Task<MoveMatchResponse> Handle(MoveMatchRequest request, CancellationToken cancellationToken)
        {
            var match = await _matchRepository.GetById(request.Id, cancellationToken);

            match.Move(request.FeatureName);

            await _context.SaveChangesAsync(cancellationToken);

            var response = new MoveMatchResponse
            {
                Id = match.Id,
                GameId = match.GameId,
                IsFinish = match.IsFinish
            };

            return response;
        }
    }
}
