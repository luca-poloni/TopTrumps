using MediatR;

namespace Application.UseCases.Player.Commands.CreatePlayer
{
    public record CreatePlayerRequest : IRequest<CreatePlayerResponse>
    {
        public Guid MatchId { get; set; } = default;
        public string Name { get; set; } = null!;
    }
}
