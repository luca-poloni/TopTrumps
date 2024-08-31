using MediatR;

namespace Application.UseCases.Match.Commands.UpdateMatch
{
    public record UpdateMatchRequest : IRequest<UpdateMatchResponse>
    {
        public Guid Id { get; set; } = default;
        public bool IsFinish { get; set; } = default;
    }
}
