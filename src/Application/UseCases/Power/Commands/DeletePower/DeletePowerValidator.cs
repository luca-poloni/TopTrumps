using FluentValidation;

namespace Application.UseCases.Power.Commands.DeletePower
{
    internal sealed class DeletePowerValidator : AbstractValidator<DeletePowerRequest>
    {
        public DeletePowerValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty()
                .WithMessage("The power id can't be empty.");
        }
    }
}
