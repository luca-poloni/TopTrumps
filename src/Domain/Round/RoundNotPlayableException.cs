using Domain.Core;

namespace Domain.Round
{
    public class RoundNotPlayableException : DomainBaseException
    {
        public RoundNotPlayableException() : base("Round is not playable.") { }
    }
}
