namespace Domain.Exceptions
{
    public class InsufficientNumberCardsException : ApplicationException
    {
        private const string DEFAULT_MESSAGE = "Insufficient number of cards to play the round.";
        public InsufficientNumberCardsException() : base(DEFAULT_MESSAGE) { }
    }
}