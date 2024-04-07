using Application.Common.Interfaces;
using MediatR;

namespace Application.UseCases.Game.Queries.GetGameById
{
    internal class GetGameByIdHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetGameByIdRequest, GetGameByIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<GetGameByIdResponse> Handle(GetGameByIdRequest request, CancellationToken cancellationToken)
        {
            var game = await _unitOfWork.GameRepository.GetByIdAsNoTrackingAsync(request.Id, cancellationToken);

            if (game == default)
                throw new GameNotFoundToGetByIdException();

            var response = new GetGameByIdResponse
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description
            };

            return response;
        }
    }
}
