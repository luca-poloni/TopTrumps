namespace Application.UseCases.Card.Commands
{
    public record CreateCardResponse
    {
        public uint Id { get; init; }
        public uint GameId { get; init; }
        public string Name { get; init; } = string.Empty;
        public byte[] Image { get; init; } = null!;
        public bool IsTopTrumps { get; init; }
    }
}
