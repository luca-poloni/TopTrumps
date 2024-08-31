using MediatR;

namespace Application.UseCases.Match.Queries.GetMatchById
{
    public record GetMatchByIdRequest : IRequest<GetMatchByIdResponse>
    {
        public Guid Id { get; set; } = default;
    }
}
