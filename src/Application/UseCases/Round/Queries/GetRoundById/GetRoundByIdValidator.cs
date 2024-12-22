using FluentValidation;

namespace Application.UseCases.Round.Queries.GetRoundById
{
    internal sealed class GetRoundByIdValidator : AbstractValidator<GetRoundByIdRequest>
    {
        public GetRoundByIdValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty()
                .WithMessage("The round id can't be empty.");
        }
    }
}
