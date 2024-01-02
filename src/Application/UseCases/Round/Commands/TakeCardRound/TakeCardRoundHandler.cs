using Application.Common.Interfaces;
using Domain.Repositores;
using MediatR;

namespace Application.UseCases.Round.Commands
{
    internal class TakeCardRoundHandler(IRoundRepository roundRepository, ICardPlayerRepository cardPlayerRepository, IApplicationDbContext context) : IRequestHandler<TakeCardRoundRequest, Unit>
    {
        private readonly IRoundRepository _roundRepository = roundRepository;
        private readonly ICardPlayerRepository _cardPlayerRepository = cardPlayerRepository;
        private readonly IApplicationDbContext _context = context;

        public async Task<Unit> Handle(TakeCardRoundRequest request, CancellationToken cancellationToken)
        {
            var round = await _roundRepository.GetById(request.Id, cancellationToken);
            var cardPlayer = await _cardPlayerRepository.GetById(request.CardPlayerId, cancellationToken);

            round.TakeCard(cardPlayer);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
