using MediatR;

namespace Application.UseCases.Match.Commands.PlayMatch
{
    public record PlayMatchRequest : IRequest<PlayMatchResponse>
    {
        public uint Id { get; init; }
    }
}
