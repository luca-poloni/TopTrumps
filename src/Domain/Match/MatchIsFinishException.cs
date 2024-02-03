using Domain.Core;

namespace Domain.Match
{
    public class MatchIsFinishException : DomainBaseException
    {
        public MatchIsFinishException() : base("Match is finish.") { }
    }
}
