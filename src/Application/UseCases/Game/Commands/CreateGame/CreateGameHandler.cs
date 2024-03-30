using Application.Common.Interfaces;
using Domain.Game;
using MediatR;

namespace Application.UseCases.Game.Commands.CreateGame
{
    internal class CreateGameHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateGameRequest, CreateGameResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<CreateGameResponse> Handle(CreateGameRequest request, CancellationToken cancellationToken)
        {
            var game = new GameEntity
            {
                Name = request.Name,
                Description = request.Description
            };

            _unitOfWork.GameRepository.Add(game);

            await _unitOfWork.CommitAsync(cancellationToken);

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
