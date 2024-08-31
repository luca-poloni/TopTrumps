namespace Application.UseCases.Match.Commands.UpdateMatch
{
    public record UpdateMatchResponse
    {
        public Guid Id { get; set; } = default;
        public Guid GameId { get; set; } = default;
        public bool IsFinish { get; set; } = default;
    }
}
