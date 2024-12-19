using MediatR;

namespace Application.UseCases.Player.Commands.DeletePlayer
{
    public record DeletePlayerRequest : IRequest
    {
        public Guid Id { get; set; } = default;
    }
}
