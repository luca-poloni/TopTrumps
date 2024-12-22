using MediatR;

namespace Application.UseCases.Match.Actions.PlayMatch
{
    public record PlayMatchRequest : IRequest
    {
        public Guid Id { get; set; } = default;
    }
}
