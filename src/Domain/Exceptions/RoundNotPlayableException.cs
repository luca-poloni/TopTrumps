namespace Domain.Exceptions
{
    public class RoundNotPlayableException : ApplicationException
    {
        private const string DEFAULT_MESSAGE = "Round is not playable.";
        public RoundNotPlayableException() : base(DEFAULT_MESSAGE) { }
    }
}
