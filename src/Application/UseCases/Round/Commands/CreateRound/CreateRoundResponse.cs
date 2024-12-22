namespace Application.UseCases.Round.Commands.CreateRound
{
    public record CreateRoundResponse
    {
        public Guid Id { get; set; } = default;
        public Guid MatchId { get; set; } = default;
        public Guid? WinnerPlayerId { get; set; }
    }
}
