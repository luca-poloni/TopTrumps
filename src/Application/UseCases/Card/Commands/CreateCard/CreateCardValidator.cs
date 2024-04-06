using FluentValidation;

namespace Application.UseCases.Card.Commands.CreateCard
{
    public class CreateCardValidator : AbstractValidator<CreateCardRequest>
    {
        public CreateCardValidator()
        {
            RuleFor(request => request.GameId)
                .NotEmpty()
                .WithMessage("The game id can't be empty.");

            RuleFor(request => request.Name)
                .NotEmpty()
                .WithMessage("The name can't be empty.");
        }
    }
}
