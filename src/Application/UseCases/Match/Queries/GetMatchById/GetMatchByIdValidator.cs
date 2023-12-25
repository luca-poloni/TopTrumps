using FluentValidation;

namespace Application.UseCases.Match.Queries
{
    public class GetMatchByIdValidator : AbstractValidator<GetMatchByIdRequest>
    {
        public GetMatchByIdValidator()
        {
            RuleFor(request => request.Id)
                .GreaterThan(uint.MinValue)
                .WithMessage("The match identifier must be greather than zero.");
        }
    }
}
