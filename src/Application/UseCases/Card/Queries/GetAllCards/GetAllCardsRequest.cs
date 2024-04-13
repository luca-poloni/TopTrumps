using MediatR;

namespace Application.UseCases.Card.Queries.GetAllCards
{
    public record GetAllCardsRequest : IRequest<IEnumerable<GetAllCardsResponse>> { }
}
