using Ardalis.Specification;
using Domain.Core.Card;

namespace Infrastructure.Specifications
{
    internal class CardByIdSpecification : SingleResultSpecification<CardEntity>
    {
        public CardByIdSpecification(Guid id)
        {
            Query.Where(card => card.Id == id);
        }
    }
}
