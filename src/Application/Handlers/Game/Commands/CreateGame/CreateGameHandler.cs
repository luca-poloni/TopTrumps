using Application.Common.Interfaces;
using Ardalis.GuardClauses;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Game.Commands.CreateGame
{
    internal class CreateGameHandler(IApplicationDbContext applicationDbContext) : IRequestHandler<CreateGameRequest, CreateGameResponse>
    {
        private readonly IApplicationDbContext _applicationDbContext = applicationDbContext;

        public async Task<CreateGameResponse> Handle(CreateGameRequest request, CancellationToken cancellationToken)
        {
            var game = new GameEntity(request.Name, request.Description);

            await _applicationDbContext.Games.AddAsync(game, cancellationToken);
            var affectedRows = await _applicationDbContext.SaveChangesAsync(cancellationToken);

            Guard.Against.NegativeOrZero(affectedRows);

            var response = new CreateGameResponse
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description
            };

            return response;
        }
    }
}
