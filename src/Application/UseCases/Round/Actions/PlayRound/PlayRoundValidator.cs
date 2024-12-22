using FluentValidation;

namespace Application.UseCases.Round.Actions.PlayRound
{
    internal sealed class PlayRoundValidator : AbstractValidator<PlayRoundRequest>
    {
        public PlayRoundValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty()
                .WithMessage("The id can't be empty.");

            RuleFor(request => request.FeatureId)
                .NotEmpty()
                .WithMessage("The feature id can't be empty.");

            RuleFor(request => request.PlayerCardIds)
                .NotEmpty()
                .WithMessage("The player card ids can't be empty.");
        }
    }
}
