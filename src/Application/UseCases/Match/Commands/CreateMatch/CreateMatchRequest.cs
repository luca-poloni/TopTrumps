using MediatR;

namespace Application.UseCases.Match.Commands.CreateMatch
{
    public record CreateMatchRequest : IRequest<CreateMatchResponse>
    {
        public Guid GameId { get; set; } = default;
    }
}
