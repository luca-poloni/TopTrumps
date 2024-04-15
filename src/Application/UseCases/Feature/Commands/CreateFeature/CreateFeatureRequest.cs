using MediatR;

namespace Application.UseCases.Feature.Commands.CreateFeature
{
    public record CreateFeatureRequest : IRequest<CreateFeatureResponse>
    {
        public Guid GameId { get; set; } = default;
        public string Name { get; set; } = null!;
    }
}
