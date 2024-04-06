using FluentValidation;

namespace Application.UseCases.Card.Commands.UpdateCard
{
    public class UpdateCardValidator : AbstractValidator<UpdateCardRequest>
    {
        public UpdateCardValidator()
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
