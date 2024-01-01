using FluentValidation;

namespace Application.UseCases.Card.Commands
{
    public class CreateCardValidator : AbstractValidator<CreateCardRequest>
    {
        public CreateCardValidator()
        {
            RuleFor(request => request.GameId)
                .GreaterThan(uint.MinValue)
                .WithMessage("The game identifier must be greather than zero.");

            RuleFor(request => request.Name)
                .NotEmpty()
                .WithMessage("The name can't be empty.");

            RuleFor(request => request.Image)
                .NotEmpty()
                .WithMessage("The image cannot be empty.");
        }
    }
}
