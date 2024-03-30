using MediatR;

namespace Application.UseCases.Game.Commands.UpdateGame
{
    public record UpdateGameRequest : IRequest<UpdateGameResponse>
    {
        public Guid Id { get; set; } = default;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
