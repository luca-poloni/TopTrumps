using Domain.Repositores;
using MediatR;

namespace Application.UseCases.Match.Queries
{
    internal class GetMatchByIdHandler(IMatchRepository matchRepository) : IRequestHandler<GetMatchByIdRequest, GetMatchByIdResponse>
    {
        private readonly IMatchRepository _matchRepository = matchRepository;

        public async Task<GetMatchByIdResponse> Handle(GetMatchByIdRequest request, CancellationToken cancellationToken)
        {
            var match = await _matchRepository.GetById(request.Id, cancellationToken);

            var response = new GetMatchByIdResponse
            {
                Id = match.Id,
                GameId = match.GameId,
                IsFinish = match.IsFinish
            };

            return response;
        }
    }
}
