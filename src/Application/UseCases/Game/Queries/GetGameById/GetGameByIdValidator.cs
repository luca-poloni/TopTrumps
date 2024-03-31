using FluentValidation;

namespace Application.UseCases.Game.Queries.GetGameById
{
    public class GetGameByIdValidator : AbstractValidator<GetGameByIdRequest>
    {
        public GetGameByIdValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty()
                .WithMessage("The id can't be empty.");
        }
    }
}
