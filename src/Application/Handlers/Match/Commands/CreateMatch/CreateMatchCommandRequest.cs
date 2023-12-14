using MediatR;

namespace Application.Handlers.Match.Commands.CreateMatch
{
    public record CreateMatchCommandRequest : IRequest<CreateMatchCommandResponse>
    {
        public uint GameId { get; init; }
    }
}
