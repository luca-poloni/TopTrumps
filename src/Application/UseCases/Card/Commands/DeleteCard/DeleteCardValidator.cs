using FluentValidation;

namespace Application.UseCases.Card.Commands.DeleteCard
{
    public class DeleteCardValidator : AbstractValidator<DeleteCardRequest>
    {
        public DeleteCardValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty()
                .WithMessage("The id can't be empty.");
        }
    }
}
