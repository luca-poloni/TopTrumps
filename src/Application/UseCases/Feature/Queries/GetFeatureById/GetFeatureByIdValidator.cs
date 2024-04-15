using FluentValidation;

namespace Application.UseCases.Feature.Queries.GetFeatureById
{
    public class GetFeatureByIdValidator : AbstractValidator<GetFeatureByIdRequest>
    {
        public GetFeatureByIdValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty()
                .WithMessage("The id can't be empty.");
        }
    }
}
