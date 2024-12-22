using FluentValidation;

namespace Application.UseCases.Round.Queries.GetAllRoundsByMatchId
{
    internal sealed class GetAllRoundsByMatchIdValidator : AbstractValidator<GetAllRoundsByMatchIdRequest>
    {
        public GetAllRoundsByMatchIdValidator()
        {
            RuleFor(request => request.MatchId)
                .NotEmpty()
                .WithMessage("The match id can't be empty.");
        }
    }
}
