namespace Domain.Exceptions
{
    public class PlayerCardsNotFoundException : Exception
    {
        private const string DEFAULT_MESSAGE = "Player cards not found.";
        public PlayerCardsNotFoundException() : base(DEFAULT_MESSAGE) { }
    }
}
