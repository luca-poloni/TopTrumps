namespace Application.UseCases.Match.Queries.GetAllMatchesByGameId
{
    public record GetAllMatchesByGameIdResponse
    {
        public Guid Id { get; set; } = default;
        public Guid GameId { get; set; } = default;
        public bool IsFinish { get; set; } = default;
    }
}
