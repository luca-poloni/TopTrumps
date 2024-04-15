using Application.Common.Exceptions;

namespace Application.UseCases.Feature.Commands.DeleteFeature
{
    public class FeatureNotFoundToDeleteException() : ApplicationBaseException("Feature not found to delete.") { }
}
