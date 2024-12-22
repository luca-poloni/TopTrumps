namespace Application.UseCases.Round.Commands.UpdateRound
{
    public record UpdateRoundResponse
    {
        public Guid Id { get; set; } = default;
        public Guid MatchId { get; set; } = default;
        public Guid? WinnerPlayerId { get; set; }
    }
}
