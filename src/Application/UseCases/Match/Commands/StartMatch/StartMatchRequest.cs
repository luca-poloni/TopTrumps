using MediatR;

namespace Application.UseCases.Match.Commands
{
    public record StartMatchRequest : IRequest<StartMatchResponse>
    {
        public uint Id { get; init; }
    }
}
