using Application.Common.Interfaces;
using Domain.Game;
using MediatR;

namespace Application.UseCases.Game.Commands.CreateGame
{
    internal class CreateGameHandler(IApplicationDbContext context) : IRequestHandler<CreateGameRequest, CreateGameResponse>
    {
        private readonly IApplicationDbContext _context = context;

        public async Task<CreateGameResponse> Handle(CreateGameRequest request, CancellationToken cancellationToken)
        {
            var game = new GameEntity
            {
                Name = request.Name,
                Description = request.Description
            };

            await _context.Games.AddAsync(game, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var response = new CreateGameResponse
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
            };

            return response;
        }
    }
}
