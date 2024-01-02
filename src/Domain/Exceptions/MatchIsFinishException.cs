namespace Domain.Exceptions
{
    public class MatchIsFinishException : ApplicationException
    {
        private const string DEFAULT_MESSAGE = "Match is finish.";
        public MatchIsFinishException() : base(DEFAULT_MESSAGE) { }
    }
}
