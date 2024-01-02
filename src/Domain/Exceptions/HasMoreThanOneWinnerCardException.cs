namespace Domain.Exceptions
{
    public class HasMoreThanOneWinnerCardException : ApplicationException
    {
        private const string DEFAULT_MESSAGE = "Has more than one winner card.";
        public HasMoreThanOneWinnerCardException() : base(DEFAULT_MESSAGE) { }
    }
}
