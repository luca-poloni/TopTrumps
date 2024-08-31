using MediatR;

namespace Application.UseCases.Match.Commands.DeleteMatch
{
    public record DeleteMatchRequest : IRequest
    {
        public Guid Id { get; set; } = default;
    }
}
