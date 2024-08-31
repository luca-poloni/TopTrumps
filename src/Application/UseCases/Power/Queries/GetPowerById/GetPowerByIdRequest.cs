using MediatR;

namespace Application.UseCases.Power.Queries.GetPowerById
{
    public record GetPowerByIdRequest : IRequest<GetPowerByIdResponse>
    {
        public Guid Id { get; set; } = default;
    }
}
