using MediatR;

namespace Application.UseCases.Player.Commands.UpdatePlayer
{
    public record UpdatePlayerRequest : IRequest<UpdatePlayerResponse>
    {
        public Guid Id { get; set; } = default;
        public string Name { get; set; } = null!;
    }
}
