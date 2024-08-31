using FluentValidation;

namespace Application.UseCases.Match.Commands.DeleteMatch
{
    internal sealed class DeleteMatchValidator : AbstractValidator<DeleteMatchRequest>
    {
        public DeleteMatchValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty()
                .WithMessage("The id can't be empty.");
        }
    }
}
