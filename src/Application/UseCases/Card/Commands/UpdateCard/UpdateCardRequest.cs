using MediatR;

namespace Application.UseCases.Card.Commands.UpdateCard
{
    public record UpdateCardRequest : IRequest<UpdateCardResponse>
    {
        public Guid Id { get; set; } = default;
        public string Name { get; set; } = null!;
        public bool IsTopTrumps { get; set; } = default;
    }
}
