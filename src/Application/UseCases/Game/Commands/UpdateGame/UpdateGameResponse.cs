namespace Application.UseCases.Game.Commands.UpdateGame
{
    public record UpdateGameResponse
    {
        public Guid Id { get; set; } = default;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
