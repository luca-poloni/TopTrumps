using MediatR;

namespace Application.UseCases.Card.Queries.GetCardById
{
    public record GetCardByIdRequest : IRequest<GetCardByIdResponse>
    {
        public Guid Id { get; set; } = default;
    }
}
