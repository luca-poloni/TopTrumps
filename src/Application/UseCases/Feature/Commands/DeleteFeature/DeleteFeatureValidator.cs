using FluentValidation;

namespace Application.UseCases.Feature.Commands.DeleteFeature
{
    public class DeleteFeatureValidator : AbstractValidator<DeleteFeatureRequest>
    {
        public DeleteFeatureValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty()
                .WithMessage("The id can't be empty.");
        }
    }
}
