using MediatR;

namespace Application.UseCases.Round.Queries.GetRoundById
{
    public record GetRoundByIdRequest : IRequest<GetRoundByIdResponse>
    {
        public Guid Id { get; set; } = default;
    }
}
