using MediatR;

namespace Application.UseCases.Feature.Commands
{
    public record CreateFeatureRequest : IRequest<CreateFeatureResponse>
    {
        public uint CardId { get; init; }
        public string Name { get; init; } = string.Empty;
        public uint Value { get; init; }
    }
}
