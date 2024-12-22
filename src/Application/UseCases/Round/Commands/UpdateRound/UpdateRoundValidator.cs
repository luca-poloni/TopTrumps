using FluentValidation;

namespace Application.UseCases.Round.Commands.UpdateRound
{
    internal sealed class UpdateRoundVValidator : AbstractValidator<UpdateRoundRequest>
    {
        public UpdateRoundVValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty()
                .WithMessage("The round id can't be empty.");
        }
    }
}
