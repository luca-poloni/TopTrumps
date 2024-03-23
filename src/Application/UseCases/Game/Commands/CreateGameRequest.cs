using MediatR;

namespace Application.UseCases.Game.Commands
{
    public class CreateGameRequest : IRequest<CreateGameResponse>
    {
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
    }
}
