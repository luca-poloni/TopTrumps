using MediatR;

namespace Application.UseCases.Match.Commands
{
    public record CreateMatchRequest : IRequest<CreateMatchResponse>
    {
        public uint GameId { get; init; }
    }
}
