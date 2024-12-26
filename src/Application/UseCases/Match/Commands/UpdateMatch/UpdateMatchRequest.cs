using MediatR;

namespace Application.UseCases.Match.Commands.UpdateMatch
{
    public record UpdateMatchRequest : IRequest<UpdateMatchResponse>
    {
        public Guid Id { get; set; } = default;
        public Guid WinnerPlayerId { get; set; } = default;
    }
}
