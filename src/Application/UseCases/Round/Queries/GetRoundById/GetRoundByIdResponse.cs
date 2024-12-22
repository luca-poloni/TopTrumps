namespace Application.UseCases.Round.Queries.GetRoundById
{
    public record GetRoundByIdResponse
    {
        public Guid Id { get; set; } = default;
        public Guid MatchId { get; set; } = default;
        public Guid? WinnerPlayerId { get; set; }
    }
}
