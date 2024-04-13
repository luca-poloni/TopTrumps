using FluentValidation;

namespace Application.UseCases.Card.Queries.GetCardById
{
    public class GetCardByIdValidator : AbstractValidator<GetCardByIdRequest>
    {
        public GetCardByIdValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty()
                .WithMessage("The id can't be empty.");
        }
    }
}
