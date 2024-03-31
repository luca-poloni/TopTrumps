using Application.Common.Interfaces;
using MediatR;

namespace Application.UseCases.Game.Queries.GetAllGames
{
    internal class GetAllGamesHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllGamesRequest, IEnumerable<GetAllGamesResponse>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IEnumerable<GetAllGamesResponse>> Handle(GetAllGamesRequest request, CancellationToken cancellationToken)
        {
            var games = await _unitOfWork.GameRepository.GetAllAsync(cancellationToken);

            var responses = new List<GetAllGamesResponse>();

            foreach (var game in games)
            {
                responses.Add(new GetAllGamesResponse
                {
                    Id = game.Id,
                    Name = game.Name,
                    Description = game.Description
                });
            }

            return responses;
        }
    }
}
