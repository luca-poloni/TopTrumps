using MediatR;

namespace Application.UseCases.Feature.Queries.GetFeatureById
{
    public record GetFeatureByIdRequest : IRequest<GetFeatureByIdResponse>
    {
        public Guid GameId { get; set; } = default;
        public Guid Id { get; set; } = default;
    }
}
