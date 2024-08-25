using MediatR;

namespace Application.UseCases.Card.Queries.GetAllCardsByGameId
{
    public record GetAllCardsByGameIdRequest : IRequest<IEnumerable<GetAllCardsByGameIdResponse>> 
    {
        public Guid GameId { get; set; } = default;
    }
}
