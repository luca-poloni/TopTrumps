using Application.UseCases.Match.Actions.PlayGame;
using FluentValidation;

namespace Application.UseCases.Match.Actions.PlayMatch
{
    internal sealed class PlayMatchValidator : AbstractValidator<PlayMatchRequest>
    {
        public PlayMatchValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty()
                .WithMessage("The id can't be empty.");
        }
    }
}
