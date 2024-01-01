using MediatR;

namespace Application.UseCases.Round.Commands
{
    public record PlayRoundRequest : IRequest<PlayRoundResponse>
    {
        public uint Id { get; init; }
        public string FeatureName { get; init; } = string.Empty;
    }
}
