using FluentValidation;

namespace Application.UseCases.Player.Commands.CreatePlayer
{
    internal sealed class CreatePlayerValidator : AbstractValidator<CreatePlayerRequest>
    {
        public CreatePlayerValidator()
        {
            RuleFor(request => request.MatchId)
                .NotEmpty()
                .WithMessage("The match id can't be empty.");

            RuleFor(request => request.Name)
                .NotEmpty()
                .WithMessage("The name can't be empty.");
        }
    }
}
