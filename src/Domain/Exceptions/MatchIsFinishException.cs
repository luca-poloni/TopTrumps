namespace Domain.Exceptions
{
    public class MatchIsFinishException : Exception
    {
        private const string DEFAULT_MESSAGE = "Match is finish.";
        public MatchIsFinishException() : base(DEFAULT_MESSAGE) { }
    }
}
