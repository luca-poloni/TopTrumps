using FluentValidation;

namespace Application.UseCases.Match.Commands
{
    public class StartMatchValidator : AbstractValidator<StartMatchRequest>
    {
        public StartMatchValidator()
        {
            RuleFor(request => request.Id)
                .GreaterThan(uint.MinValue)
                .WithMessage("The match identifier must be greather than zero.");
        }
    }
}
