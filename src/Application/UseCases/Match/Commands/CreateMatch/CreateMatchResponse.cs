namespace Application.UseCases.Match.Commands.CreateMatch
{
    public record CreateMatchResponse
    {
        public Guid Id { get; set; } = default;
        public Guid GameId { get; set; } = default;
        public Guid? WinnerPlayerId { get; set; } 
    }
}
