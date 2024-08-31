using FluentValidation;

namespace Application.UseCases.Match.Commands.CreateMatch
{
    internal sealed class CreateMatchValidator : AbstractValidator<CreateMatchRequest>
    {
        public CreateMatchValidator()
        {
            RuleFor(request => request.GameId)
                .NotEmpty()
                .WithMessage("The game id can't be empty.");
        }
    }
}
