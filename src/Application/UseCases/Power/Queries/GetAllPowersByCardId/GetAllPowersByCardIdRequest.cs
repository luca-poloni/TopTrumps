using MediatR;

namespace Application.UseCases.Power.Queries.GetAllPowersByCardId
{
    public record GetAllPowersByCardIdRequest : IRequest<IEnumerable<GetAllPowersByCardIdResponse>>
    {
        public Guid CardId { get; set; } = default;
    }
}
