using Domain.Core;

namespace Domain.Round
{
    public class RepeatedPlayerException : DomainBaseException
    {
        public RepeatedPlayerException() : base("Player is repeated in the round.") { }
    }
}
