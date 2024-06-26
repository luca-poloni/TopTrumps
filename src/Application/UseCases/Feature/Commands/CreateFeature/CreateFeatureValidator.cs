using FluentValidation;

namespace Application.UseCases.Feature.Commands.CreateFeature
{
    internal sealed class CreateFeatureValidator : AbstractValidator<CreateFeatureRequest>
    {
        public CreateFeatureValidator()
        {
            RuleFor(request => request.GameId)
                .NotEmpty()
                .WithMessage("The game id can't be empty.");

            RuleFor(request => request.Name)
                .NotEmpty()
                .WithMessage("The name can't be empty.");
        }
    }
}
