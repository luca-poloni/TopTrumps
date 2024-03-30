using FluentValidation;

namespace Application.UseCases.Game.Commands.DeleteGame
{
    public class DeleteGameValidator : AbstractValidator<DeleteGameRequest>
    {
        public DeleteGameValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty()
                .WithMessage("The id can't be empty.");
        }
    }
}
