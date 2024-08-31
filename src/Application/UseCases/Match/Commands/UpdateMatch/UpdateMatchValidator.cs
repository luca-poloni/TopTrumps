using FluentValidation;

namespace Application.UseCases.Match.Commands.UpdateMatch
{
    internal class UpdateMatchValidator : AbstractValidator<UpdateMatchRequest>
    {
        public UpdateMatchValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty()
                .WithMessage("The id can't be empty.");
        }
    }
}
