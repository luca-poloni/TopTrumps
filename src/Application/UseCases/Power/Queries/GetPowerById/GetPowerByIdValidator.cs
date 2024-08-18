﻿using FluentValidation;

namespace Application.UseCases.Power.Queries.GetPowerByCardId
{
    internal sealed class GetPowerByIdValidator : AbstractValidator<GetPowerByIdRequest>
    {
        public GetPowerByIdValidator()
        {
            RuleFor(request => request.Id)
                .NotEmpty()
                .WithMessage("The power id can't be empty.");
        }
    }
}