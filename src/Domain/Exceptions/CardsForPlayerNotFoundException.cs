namespace Domain.Exceptions
{
    public class CardsForPlayerNotFoundException : Exception
    {
        private const string DEFAULT_MESSAGE = "Cards for player not found.";
        public CardsForPlayerNotFoundException() : base(DEFAULT_MESSAGE) { }
    }
}
