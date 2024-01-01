using FluentValidation;

namespace Application.UseCases.Round.Commands
{
    public class PlayRoundValidator : AbstractValidator<PlayRoundRequest>
    {
        public PlayRoundValidator()
        {
            RuleFor(request => request.Id)
                .GreaterThan(uint.MinValue)
                .WithMessage("The round identifier must be greather than zero.");

            RuleFor(request => request.FeatureName)
                .NotEmpty()
                .WithMessage("The feature name cannot be empty.");
        }
    }
}
