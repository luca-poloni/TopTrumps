using FluentValidation;

namespace Application.UseCases.Player.Commands.DeletePlayer
{
    internal sealed class DeletePlayerValidator : AbstractValidator<DeletePlayerRequest>
    {
        public DeletePlayerValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty()
                .WithMessage("The id can't be empty.");
        }
    }
}
