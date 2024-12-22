using MediatR;

namespace Application.UseCases.Round.Commands.UpdateRound
{
    public record UpdateRoundRequest : IRequest<UpdateRoundResponse>
    {
        public Guid Id { get; set; } = default;
        public Guid? WinnerPlayerId { get; set; }
    }
}
