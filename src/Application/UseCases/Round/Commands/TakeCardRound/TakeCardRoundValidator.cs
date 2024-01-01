using FluentValidation;

namespace Application.UseCases.Round.Commands
{
    public class TakeCardRoundValidator : AbstractValidator<TakeCardRoundRequest>
    {
        public TakeCardRoundValidator()
        {
            RuleFor(request => request.Id)
                .GreaterThan(uint.MinValue)
                .WithMessage("The round identifier must be greather than zero.");

            RuleFor(request => request.CardPlayerId)
                .GreaterThan(uint.MinValue)
                .WithMessage("The card player identifier must be greather than zero.");
        }
    }
}