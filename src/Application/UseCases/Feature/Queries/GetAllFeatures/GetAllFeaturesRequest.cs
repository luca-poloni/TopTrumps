using MediatR;

namespace Application.UseCases.Feature.Queries.GetAllFeatures
{
    public record GetAllFeaturesRequest : IRequest<IEnumerable<GetAllFeaturesResponse>> { }
}
