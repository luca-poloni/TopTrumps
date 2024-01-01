using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Feature.Commands
{
    internal class CreateFeatureHandler(IApplicationDbContext context) : IRequestHandler<CreateFeatureRequest, CreateFeatureResponse>
    {
        private readonly IApplicationDbContext _context = context;

        public async Task<CreateFeatureResponse> Handle(CreateFeatureRequest request, CancellationToken cancellationToken)
        {
            var feature = new FeatureEntity(request.CardId, request.Name, request.Value);

            await _context.Features.AddAsync(feature, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var response = new CreateFeatureResponse
            {
                Id = feature.Id,
                CardId = feature.CardId,
                Name = feature.Name,
                Value = feature.Value
            };

            return response;
        }
    }
}
