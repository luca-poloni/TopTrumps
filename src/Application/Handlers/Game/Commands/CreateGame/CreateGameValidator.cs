using FluentValidation;

namespace Application.Handlers.Game.Commands.CreateGame
{
    public class CreateGameValidator : AbstractValidator<CreateGameRequest>
    {
        public CreateGameValidator()
        {
            RuleFor(request => request.Name)
                .NotEmpty()
                .WithMessage("The name can't be empty.");

            RuleFor(request => request.Description)
                .NotEmpty()
                .WithMessage("The description can't be empty.");
        }
    }
}
