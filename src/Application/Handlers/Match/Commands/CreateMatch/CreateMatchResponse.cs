namespace Application.Handlers.Match.Commands.CreateMatch
{
    public record CreateMatchResponse
    {
        public uint Id { get; init; }
        public uint GameId { get; init; }
        public bool IsFinish { get; init; }
    }
}
