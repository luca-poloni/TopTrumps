using FluentValidation;

namespace Application.UseCases.Power.Commands.UpdatePower
{
    internal sealed class UpdatePowerValidator : AbstractValidator<UpdatePowerRequest>
    {
        public UpdatePowerValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty()
                .WithMessage("The power id can't be empty.");

            RuleFor(request => request.Value)
                .GreaterThan(0u)
                .WithMessage("The value can't be less or equal to zero.");
        }
    }
}
