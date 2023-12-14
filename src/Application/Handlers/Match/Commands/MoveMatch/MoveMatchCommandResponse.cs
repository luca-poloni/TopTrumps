namespace Application.Handlers.Match.Commands.MoveMatch
{
    public record MoveMatchCommandResponse
    {
        public uint Id { get; init; }
        public uint GameId { get; init; }
        public bool IsFinish { get; init; }
    }
}
