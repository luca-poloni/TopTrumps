namespace Application.UseCases.Round.Commands
{
    public record CreateRoundResponse
    {
        public uint Id { get; init; }
        public uint MatchId { get; init; }
        public uint? WinnerPlayerId { get; init; }
    }
}
