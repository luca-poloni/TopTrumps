using MediatR;

namespace Application.UseCases.Match.Queries
{
    public record GetMatchByIdRequest : IRequest<GetMatchByIdResponse>
    {
        public uint Id { get; init; }
    }
}
