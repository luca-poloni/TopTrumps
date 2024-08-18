using FluentValidation;

namespace Application.UseCases.Power.Commands.CreatePower
{
    internal sealed class CreatePowerValidator : AbstractValidator<CreatePowerRequest>
    {
        public CreatePowerValidator()
        {
            RuleFor(request => request.CardId)
                .NotEmpty()
                .WithMessage("The card id can't be empty.");

            RuleFor(request => request.FeatureId)
                .NotEmpty()
                .WithMessage("The feature id can't be empty.");

            RuleFor(request => request.Value)
                .GreaterThan(0u)
                .WithMessage("The value can't be less or equal to zero.");
        }
    }
}
