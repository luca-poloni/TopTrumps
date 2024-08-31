using FluentValidation;

namespace Application.UseCases.Match.Queries.GetAllMatchesByGameId
{
    internal sealed class GetAllMatchesByGameIdValidator : AbstractValidator<GetAllMatchesByGameIdRequest>
    {
        public GetAllMatchesByGameIdValidator()
        {
            RuleFor(request => request.GameId)
                .NotEmpty()
                .WithMessage("The game id can't be empty.");
        }
    }
}
