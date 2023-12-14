using MediatR;

namespace Application.Handlers.Match.Commands.UpdateMatch
{
    public record UpdateMatchCommandRequest : IRequest<UpdateMatchCommandResponse>
    {
        public uint Id { get; init; }
        public string FeatureName { get; init; } = null!;
    }
}
