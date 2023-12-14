using MediatR;

namespace Application.Handlers.Game.Commands.CreateGame
{
    public record CreateGameRequest : IRequest<CreateGameResponse>
    {
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
    }
}
