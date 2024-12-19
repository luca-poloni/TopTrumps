using FluentValidation;

namespace Application.UseCases.Player.Commands.UpdatePlayer
{
    internal sealed class UpdatePlayerValidator : AbstractValidator<UpdatePlayerRequest>
    {
        public UpdatePlayerValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty()
                .WithMessage("The id can't be empty.");

            RuleFor(request => request.Name)
                .NotEmpty()
                .WithMessage("The name can't be empty.");
        }
    }
}
