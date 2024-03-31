namespace Application.UseCases.Game.Queries.GetAllGames
{
    public record GetAllGamesResponse
    {
        public Guid Id { get; set; } = default;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
