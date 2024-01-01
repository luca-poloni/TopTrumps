using FluentValidation;

namespace Application.UseCases.Feature.Commands
{
    public class CreateFeatureValidator : AbstractValidator<CreateFeatureRequest>
    {
        public CreateFeatureValidator()
        {
            RuleFor(request => request.CardId)
                .GreaterThan(uint.MinValue)
                .WithMessage("The card identifier must be greather than zero.");

            RuleFor(request => request.Name)
                .NotEmpty()
                .WithMessage("The name can't be empty.");
        }
    }
}
