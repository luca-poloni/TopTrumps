using MediatR;

namespace Application.UseCases.Power.Queries.GetPowerByCardId
{
    public record GetPowerByIdRequest : IRequest<GetPowerByIdResponse>
    {
        public Guid Id { get; set; } = default;
    }
}
