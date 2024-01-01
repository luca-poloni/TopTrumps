using FluentValidation;

namespace Application.UseCases.Round.Commands
{
    public class CreateRoundValidator : AbstractValidator<CreateRoundRequest>
    {
        public CreateRoundValidator()
        {
            RuleFor(request => request.MatchId)
                .GreaterThan(uint.MinValue)
                .WithMessage("The match identifier must be greather than zero.");
        }
    }
}
