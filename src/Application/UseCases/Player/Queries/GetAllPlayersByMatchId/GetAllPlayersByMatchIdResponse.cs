namespace Application.UseCases.Player.Queries.GetAllPlayersByMatchId
{
    public record GetAllPlayersByMatchIdResponse
    {
        public Guid Id { get; set; } = default;
        public Guid MatchId { get; set; } = default;
        public string Name { get; set; } = null!;
    }
}
