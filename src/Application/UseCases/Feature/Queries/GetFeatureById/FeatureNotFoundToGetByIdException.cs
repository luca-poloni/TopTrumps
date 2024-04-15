using Application.Common.Exceptions;

namespace Application.UseCases.Feature.Queries.GetFeatureById
{
    public class FeatureNotFoundToGetByIdException() : ApplicationBaseException("Feature not found to get by id.") { }
}
