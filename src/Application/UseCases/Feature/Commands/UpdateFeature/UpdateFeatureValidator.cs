using FluentValidation;

namespace Application.UseCases.Feature.Commands.UpdateFeature
{
    public class UpdateFeatureValidator : AbstractValidator<UpdateFeatureRequest>
    {
        public UpdateFeatureValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty()
                .WithMessage("The id can't be empty.");

            RuleFor(request => request.Name)
                .NotEmpty()
                .WithMessage("The name can't be empty.");
        }
    }
}
