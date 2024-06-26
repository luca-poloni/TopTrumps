using Ardalis.SharedKernel;
using Domain.Game;
using MediatR;

namespace Application.UseCases.Game.Queries.GetGameById
{
    internal class GetGameByIdHandler(IReadRepository<GameAggregate> repository) : IRequestHandler<GetGameByIdRequest, GetGameByIdResponse>
    {
        public async Task<GetGameByIdResponse> Handle(GetGameByIdRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .GetByIdAsync(request.Id, cancellationToken) ?? throw new ArgumentException("Game not found to get by id.");

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
