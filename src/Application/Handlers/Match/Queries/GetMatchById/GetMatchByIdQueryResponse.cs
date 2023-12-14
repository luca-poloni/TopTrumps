namespace Application.Handlers.Match.Queries.GetMatchById
{
    public record GetMatchByIdQueryResponse
    {
        public uint Id { get; init; }
        public uint GameId { get; init; }
        public bool IsFinish { get; init; }
    }
}
