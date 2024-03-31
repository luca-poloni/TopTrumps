namespace Application.UseCases.Game.Queries.GetGameById
{
    public record GetGameByIdResponse
    {
        public Guid Id { get; set; } = default;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
