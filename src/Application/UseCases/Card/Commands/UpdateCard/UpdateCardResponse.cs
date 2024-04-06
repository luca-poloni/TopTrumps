namespace Application.UseCases.Card.Commands.UpdateCard
{
    public record UpdateCardResponse
    {
        public Guid Id { get; set; } = default;
        public Guid GameId { get; set; } = default;
        public string Name { get; set; } = null!;
        public bool IsTopTrumps { get; set; } = default;
    }
}
