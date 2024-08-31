using MediatR;

namespace Application.UseCases.Match.Queries.GetAllMatchesByGameId
{
    public record GetAllMatchesByGameIdRequest : IRequest<IEnumerable<GetAllMatchesByGameIdResponse>>
    {
        public Guid GameId { get; set; } = default;
    }
}
