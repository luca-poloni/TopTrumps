using MediatR;

namespace Application.UseCases.Player.Queries.GetAllPlayersByMatchId
{
    public record GetAllPlayersByMatchIdRequest : IRequest<IEnumerable<GetAllPlayersByMatchIdResponse>>
    {
        public Guid MatchId { get; set; } = default;
    }
}
