using MediatR;

namespace Application.UseCases.Feature.Queries.GetAllFeaturesByGameId
{
    public record GetAllFeaturesByGameIdRequest : IRequest<IEnumerable<GetAllFeaturesByGameIdResponse>> 
    {
        public Guid GameId { get; set; } = default;
    }
}
