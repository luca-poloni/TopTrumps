using MediatR;

namespace Application.UseCases.Match.Commands
{
    public record PlayMatchRequest : IRequest<PlayMatchResponse>
    {
        public uint Id { get; init; }
    }
}
