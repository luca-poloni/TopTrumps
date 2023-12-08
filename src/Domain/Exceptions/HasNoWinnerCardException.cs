namespace Domain.Exceptions
{
    public class HasNoWinnerCardException : Exception
    {
        private const string DEFAULT_MESSAGE = "Has no winner card.";
        public HasNoWinnerCardException() : base(DEFAULT_MESSAGE) { }
    }
}
