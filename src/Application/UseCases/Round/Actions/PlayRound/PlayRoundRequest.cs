using MediatR;

namespace Application.UseCases.Round.Actions.PlayRound
{
    public record PlayRoundRequest : IRequest<PlayRoundResponse>
    {
        public Guid Id { get; set; } = default;
        public Guid FeatureId { get; set; }
        public IEnumerable<Guid> PlayerCardIds { get; set; } = [];
    }
}
