namespace Application.UseCases.Match.Commands
{
    public record PlayMatchResponse
    {
        public uint Id { get; init; }
        public uint GameId { get; init; }
        public bool IsFinish { get; init; }
    }
}
