namespace Application.UseCases.Player.Commands
{
    public record CreatePlayerResponse
    {
        public uint Id { get; init; }
        public uint MatchId { get; init; }
        public string Name { get; init; } = string.Empty;
    }
}
