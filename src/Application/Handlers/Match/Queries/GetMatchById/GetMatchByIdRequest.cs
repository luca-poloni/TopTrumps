using MediatR;

namespace Application.Handlers.Match.Queries.GetMatchById
{
    public record GetMatchByIdRequest : IRequest<GetMatchByIdResponse>
    {
        public uint Id { get; init; }
    }
}
