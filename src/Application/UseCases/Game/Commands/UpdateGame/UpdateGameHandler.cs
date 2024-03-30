using Application.Common.Interfaces;
using MediatR;

namespace Application.UseCases.Game.Commands.UpdateGame
{
    internal class UpdateGameHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateGameRequest, UpdateGameResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<UpdateGameResponse> Handle(UpdateGameRequest request, CancellationToken cancellationToken)
        {
            var game = await _unitOfWork.GameRepository.GetByIdAsync(request.Id, cancellationToken);

            if (game == default)
                throw new ArgumentException("Game not found.");

            game.Update(request.Name, request.Description);

            _unitOfWork.GameRepository.Update(game);

            await _unitOfWork.CommitAsync(cancellationToken);

            var response = new UpdateGameResponse
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
            };

            return response;
        }
    }
}
