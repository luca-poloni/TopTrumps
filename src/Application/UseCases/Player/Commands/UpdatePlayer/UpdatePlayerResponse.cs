namespace Application.UseCases.Player.Commands.UpdatePlayer
{
    public record UpdatePlayerResponse
    {
        public Guid Id { get; set; } = default;
        public Guid MatchId { get; set; } = default;
        public string Name { get; set; } = null!;
    }
}
