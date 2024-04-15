using Ardalis.Specification;
using Domain.Core.Feature;

namespace Infrastructure.Specifications
{
    internal class FeatureByIdSpecification : SingleResultSpecification<FeatureEntity>
    {
        public FeatureByIdSpecification(Guid id)
        {
            Query.Where(feature => feature.Id == id);
        }
    }
}
