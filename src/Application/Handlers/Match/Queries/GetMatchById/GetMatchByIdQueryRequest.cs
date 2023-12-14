using MediatR;

namespace Application.Handlers.Match.Queries.GetMatchById
{
    public record GetMatchByIdQueryRequest : IRequest<GetMatchByIdQueryResponse>
    {
        public uint Id { get; init; }
    }
}
