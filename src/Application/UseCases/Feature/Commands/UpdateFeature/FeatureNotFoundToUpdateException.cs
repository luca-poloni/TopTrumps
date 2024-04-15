using Application.Common.Exceptions;

namespace Application.UseCases.Feature.Commands.UpdateFeature
{
    public class FeatureNotFoundToUpdateException() : ApplicationBaseException("Feature not found to update.") { }
}
