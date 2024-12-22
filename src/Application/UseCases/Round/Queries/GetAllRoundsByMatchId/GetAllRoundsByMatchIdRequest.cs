using MediatR;

namespace Application.UseCases.Round.Queries.GetAllRoundsByMatchId
{
    public record GetAllRoundsByMatchIdRequest : IRequest<IEnumerable<GetAllRoundsByMatchIdResponse>>
    {
        public Guid MatchId { get; set; } = default;
    }
}
