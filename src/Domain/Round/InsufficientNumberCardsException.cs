using Domain.Core;

namespace Domain.Round
{
    public class InsufficientNumberCardsException : DomainBaseException
    {
        public InsufficientNumberCardsException() : base("Insufficient number of cards to play the round.") { }
    }
}
