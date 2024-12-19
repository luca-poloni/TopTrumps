using FluentValidation;

namespace Application.UseCases.Player.Queries.GetAllPlayersByMatchId
{
    internal sealed class GetAllPlayersByMatchIdValidator : AbstractValidator<GetAllPlayersByMatchIdRequest>
    {
        public GetAllPlayersByMatchIdValidator()
        {
            RuleFor(request => request.MatchId)
                .NotEmpty()
                .WithMessage("The match id can't be empty.");
        }
    }
}
