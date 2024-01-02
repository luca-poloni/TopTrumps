namespace Domain.Exceptions
{
    public class HasNoWinnerCardException : ApplicationException
    {
        private const string DEFAULT_MESSAGE = "Has no winner card.";
        public HasNoWinnerCardException() : base(DEFAULT_MESSAGE) { }
    }
}
