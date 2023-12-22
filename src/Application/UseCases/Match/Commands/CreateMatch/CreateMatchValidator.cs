using FluentValidation;

namespace Application.UseCases.Match.Commands.CreateMatch
{
    public class CreateMatchValidator : AbstractValidator<CreateMatchRequest>
    {
        public CreateMatchValidator()
        {
            RuleFor(request => request.GameId)
                .GreaterThan(uint.MinValue)
                .WithMessage("The game identifier must be greather than zero.");
        }
    }
}
