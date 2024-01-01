using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Player.Commands
{
    internal class CreatePlayerHandler(IApplicationDbContext context) : IRequestHandler<CreatePlayerRequest, CreatePlayerResponse>
    {
        private readonly IApplicationDbContext _context = context;

        public async Task<CreatePlayerResponse> Handle(CreatePlayerRequest request, CancellationToken cancellationToken)
        {
            var player = new PlayerEntity(request.MatchId, request.Name);

            await _context.Players.AddAsync(player, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var response = new CreatePlayerResponse
            {
                Id = player.Id,
                MatchId = player.MatchId,
                Name = player.Name
            };

            return response;
        }
    }
}
