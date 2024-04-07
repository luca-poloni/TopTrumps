using Application.Common.Interfaces;
using MediatR;

namespace Application.UseCases.Game.Commands.DeleteGame
{
    internal class DeleteGameHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteGameRequest>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(DeleteGameRequest request, CancellationToken cancellationToken)
        {
            var game = await _unitOfWork.GameRepository.GetByIdAsync(request.Id, cancellationToken);

            if (game == default)
                throw new GameNotFoundToDeleteException();

            _unitOfWork.GameRepository.Delete(game);

            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
