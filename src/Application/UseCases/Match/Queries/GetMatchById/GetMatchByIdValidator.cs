using FluentValidation;

namespace Application.UseCases.Match.Queries.GetMatchById
{
    internal sealed class GetMatchByIdValidator : AbstractValidator<GetMatchByIdRequest>
    {
        public GetMatchByIdValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty()
                .WithMessage("The id can't be empty.");
        }
    }
}
