using MediatR;

namespace Application.UseCases.Game.Commands.DeleteGame
{
    public record DeleteGameRequest : IRequest
    {
        public Guid Id { get; set; } = default;
    }
}
