namespace Application.UseCases.Match.Commands
{
    public record StartMatchResponse
    {
        public uint Id { get; init; }
        public uint GameId { get; init; }
        public bool IsFinish { get; init; }
    }
}
