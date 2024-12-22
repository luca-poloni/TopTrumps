namespace Application.UseCases.Round.Queries.GetAllRoundsByMatchId
{
    public record GetAllRoundsByMatchIdResponse
    {
        public Guid Id { get; set; } = default;
        public Guid MatchId { get; set; } = default;
        public Guid? WinnerPlayerId { get; set; }
    }
}
