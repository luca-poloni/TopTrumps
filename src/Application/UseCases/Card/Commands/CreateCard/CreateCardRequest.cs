using MediatR;

namespace Application.UseCases.Card.Commands.CreateCard
{
    public record CreateCardRequest : IRequest<CreateCardResponse>
    {
        public Guid GameId { get; set; } = default;
        public string Name { get; set; } = null!;
        public bool IsTopTrumps { get; set; } = default;
    }
}
