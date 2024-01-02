namespace Domain.Exceptions
{
    public class CardNotFoundException : ApplicationException
    {
        private const string DEFAULT_MESSAGE = "Card not found.";
        public CardNotFoundException() : base(DEFAULT_MESSAGE) { }
    }
}
