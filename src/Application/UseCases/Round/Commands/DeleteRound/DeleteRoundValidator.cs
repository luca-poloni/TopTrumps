using FluentValidation;

namespace Application.UseCases.Round.Commands.DeleteRound
{
    internal sealed class DeleteRoundValidator : AbstractValidator<DeleteRoundRequest>
    {
        public DeleteRoundValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty()
                .WithMessage("The id can't be empty.");
        }
    }
}
