using FluentValidation;

namespace Application.UseCases.Game.Commands.UpdateGame
{
    public class UpdateGameValidator : AbstractValidator<UpdateGameRequest>
    {
        public UpdateGameValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty()
                .WithMessage("The id can't be empty.");
            
            RuleFor(request => request.Name)
                .NotEmpty()
                .WithMessage("The name can't be empty.");

            RuleFor(request => request.Description)
                .NotEmpty()
                .WithMessage("The description can't be empty.");
        }
    }
}
