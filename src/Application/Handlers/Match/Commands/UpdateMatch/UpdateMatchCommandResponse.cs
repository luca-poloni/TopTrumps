namespace Application.Handlers.Match.Commands.UpdateMatch
{
    public record UpdateMatchCommandResponse
    {
        public uint Id { get; init; }
        public uint GameId { get; init; }
        public bool IsFinish { get; init; }
    }
}
