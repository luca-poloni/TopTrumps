namespace Application.UseCases.Player.Queries.GetPlayerById
{
    public record GetPlayerByIdResponse
    {
        public Guid Id { get; set; } = default;
        public Guid MatchId { get; set; } = default;
        public string Name { get; set; } = null!;
    }
}
