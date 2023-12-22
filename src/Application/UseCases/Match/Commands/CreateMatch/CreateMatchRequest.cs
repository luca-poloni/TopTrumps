using MediatR;

namespace Application.UseCases.Match.Commands.CreateMatch
{
    public record CreateMatchRequest : IRequest<CreateMatchResponse>
    {
        public uint GameId { get; init; }
    }
}
