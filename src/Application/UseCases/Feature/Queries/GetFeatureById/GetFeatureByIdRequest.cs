using MediatR;

namespace Application.UseCases.Feature.Queries.GetFeatureById
{
    public record GetFeatureByIdRequest : IRequest<GetFeatureByIdResponse>
    {
        public Guid Id { get; set; } = default;
    }
}
