namespace Application.Handlers.Match.Commands.PlayMatch
{
    public record PlayMatchCommandResponse
    {
        public uint Id { get; init; }
        public uint GameId { get; init; }
        public bool IsFinish { get; init; }
    }
}
