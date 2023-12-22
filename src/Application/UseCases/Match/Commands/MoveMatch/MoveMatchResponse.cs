namespace Application.UseCases.Match.Commands.MoveMatch
{
    public record MoveMatchResponse
    {
        public uint Id { get; init; }
        public uint GameId { get; init; }
        public bool IsFinish { get; init; }
    }
}
