using FluentValidation;

namespace Application.UseCases.Round.Commands.CreateRound
{
    internal sealed class CreateRoundValidator : AbstractValidator<CreateRoundRequest>
    {
        public CreateRoundValidator()
        {
            RuleFor(request => request.MatchId)
                .NotEmpty()
                .WithMessage("The match id can't be empty.");
        }
    }
}
