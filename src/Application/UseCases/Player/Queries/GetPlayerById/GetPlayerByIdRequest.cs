using MediatR;

namespace Application.UseCases.Player.Queries.GetPlayerById
{
    public record GetPlayerByIdRequest : IRequest<GetPlayerByIdResponse>
    {
        public Guid Id { get; set; } = default;
    }
}
