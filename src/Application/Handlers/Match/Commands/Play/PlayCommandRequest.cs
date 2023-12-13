using FluentResults;
using MediatR;

namespace Application.Handlers.Match.Commands.Play
{
    public record PlayCommandRequest : IRequest<Result>
    {
        public uint MatchId { get; init; }
    }
}
