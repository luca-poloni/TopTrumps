using FluentValidation;

namespace Application.UseCases.Match.Commands
{
    public class MoveMatchValidator : AbstractValidator<MoveMatchRequest>
    {
        public MoveMatchValidator()
        {
            RuleFor(request => request.Id)
                .GreaterThan(uint.MinValue)
                .WithMessage("The match identifier must be greather than zero.");

            RuleFor(request => request.FeatureName)
                .NotEmpty()
                .WithMessage("The feature name can't be empty.");
        }
    }
}
