using MediatR;

namespace Application.UseCases.Round.Commands
{
    public record TakeCardRoundRequest : IRequest<Unit>
    {
        public uint Id { get; init; }
        public uint CardPlayerId { get; init; }
    }
}
