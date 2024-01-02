namespace Domain.Exceptions
{
    public class RepeatedPlayerException : ApplicationException
    {
        private const string DEFAULT_MESSAGE = "Player is repeated in the round.";
        public RepeatedPlayerException() : base(DEFAULT_MESSAGE) { }
    }
}
