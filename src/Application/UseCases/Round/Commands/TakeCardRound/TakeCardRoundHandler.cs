using Application.Common.Interfaces;
using Domain.Repositores;
using MediatR;

namespace Application.UseCases.Round.Commands
{
    internal class TakeCardRoundHandler(IRoundRepository roundRepository, IApplicationDbContext context) : IRequestHandler<TakeCardRoundRequest, Unit>
    {
        private readonly IRoundRepository _roundRepository = roundRepository;
        private readonly IApplicationDbContext _context = context;

        public async Task<Unit> Handle(TakeCardRoundRequest request, CancellationToken cancellationToken)
        {
            var round = await _roundRepository.GetById(request.Id, cancellationToken);

            round.TakeCard(request.CardPlayerId);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
