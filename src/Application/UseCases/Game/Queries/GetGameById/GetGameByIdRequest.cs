using MediatR;

namespace Application.UseCases.Game.Queries.GetGameById
{
    public record GetGameByIdRequest : IRequest<GetGameByIdResponse>
    {
        public Guid Id { get; set; } = default;
    }
}
