namespace Application.UseCases.Round.Commands
{
    public record PlayRoundResponse
    {
        public uint Id { get; init; }
        public uint MatchId { get; init; }
        public uint? WinnerPlayerId { get; init; }
    }
}
