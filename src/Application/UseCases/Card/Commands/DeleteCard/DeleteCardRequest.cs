using MediatR;

namespace Application.UseCases.Card.Commands.DeleteCard
{
    public record DeleteCardRequest : IRequest
    {
        public Guid Id { get; set; } = default;
        public Guid GameId { get; set; } = default;
    }
}
