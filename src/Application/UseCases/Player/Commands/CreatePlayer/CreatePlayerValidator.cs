using FluentValidation;

namespace Application.UseCases.Player.Commands
{
    public class CreatePlayerValidator : AbstractValidator<CreatePlayerRequest>
    {
        public CreatePlayerValidator()
        {
            RuleFor(request => request.MatchId)
                .GreaterThan(uint.MinValue)
                .WithMessage("The match identifier must be greather than zero.");

            RuleFor(request => request.Name)
                .NotEmpty()
                .WithMessage("The name can't be empty.");
        }
    }
}
