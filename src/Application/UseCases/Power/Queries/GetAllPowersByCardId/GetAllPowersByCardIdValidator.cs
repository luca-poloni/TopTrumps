using FluentValidation;

namespace Application.UseCases.Power.Queries.GetAllPowersByCardId
{
    internal sealed class GetAllPowersByCardIdValidator : AbstractValidator<GetAllPowersByCardIdRequest>
    {
        public GetAllPowersByCardIdValidator()
        {
            RuleFor(request => request.CardId)
                .NotEmpty()
                .WithMessage("The card id can't be empty.");
        }
    }
}
