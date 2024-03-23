namespace Application.UseCases.Game.Commands
{
    public record CreateGameResponse 
    {
        public Guid Id { get; set; } = default;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
