namespace Application.UseCases.Player.Commands.CreatePlayer
{
    public record CreatePlayerResponse
    {
        public Guid Id { get; set; } = default;
        public Guid MatchId { get; set; } = default;
        public string Name { get; set; } = null!;
    }
}
