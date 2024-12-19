using FluentValidation;

namespace Application.UseCases.Player.Queries.GetPlayerById
{
    internal sealed class GetPlayerByIdValidator : AbstractValidator<GetPlayerByIdRequest>
    {
        public GetPlayerByIdValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty()
                .WithMessage("The id can't be empty.");
        }
    }
}
