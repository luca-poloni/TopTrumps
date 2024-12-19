using MediatR;

namespace Application.UseCases.Match.Actions.PlayGame
{
    public record PlayMatchRequest : IRequest
    {
        public Guid Id { get; set; } = default;
    }
}
