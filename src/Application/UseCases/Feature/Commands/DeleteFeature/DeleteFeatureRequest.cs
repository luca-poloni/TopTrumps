using MediatR;

namespace Application.UseCases.Feature.Commands.DeleteFeature
{
    public record DeleteFeatureRequest : IRequest
    {
        public Guid Id { get; set; } = default;
    }
}
