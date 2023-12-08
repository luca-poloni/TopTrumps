namespace Domain.Exceptions
{
    public class CardNotFoundException : Exception
    {
        private const string DEFAULT_MESSAGE = "Card not found.";
        public CardNotFoundException() : base(DEFAULT_MESSAGE) { }
    }
}
