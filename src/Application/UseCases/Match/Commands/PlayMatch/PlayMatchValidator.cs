using FluentValidation;

namespace Application.UseCases.Match.Commands
{
    public class PlayMatchValidator : AbstractValidator<PlayMatchRequest>
    {
        public PlayMatchValidator()
        {
            RuleFor(request => request.Id)
                .GreaterThan(uint.MinValue)
                .WithMessage("The match identifier must be greather than zero.");
        }
    }
}
