using MediatR;

namespace Application.Handlers.Match.Commands.CreateMatch
{
    public record CreateMatchRequest : IRequest<CreateMatchResponse>
    {
        public uint GameId { get; init; }
    }
}
