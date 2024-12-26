namespace Application.UseCases.Match.Commands.UpdateMatch
{
    public record UpdateMatchResponse
    {
        public Guid Id { get; set; } = default;
        public Guid GameId { get; set; } = default;
        public Guid? WinnerPlayerId { get; set; } = default;
    }
}
