using Ardalis.Specification.EntityFrameworkCore;
using Domain.Core.Feature;
using Infrastructure.Context;
using Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class FeatureRepository(ApplicationDbContext context) : IFeatureRepository
    {
        private readonly ApplicationDbContext _context = context;

        public void Add(FeatureEntity feature)
        {
            _context.Features.Add(feature);
        }
        public void Update(FeatureEntity feature)
        {
            _context.Features.Update(feature);
        }

        public void Delete(FeatureEntity feature)
        {
            _context.Features.Remove(feature);
        }

        public async Task<FeatureEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Features
                .WithSpecification(new FeatureByIdSpecification(id))
                .SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<FeatureEntity?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Features
                .AsNoTracking()
                .WithSpecification(new FeatureByIdSpecification(id))
                .SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<FeatureEntity>> GetAllAsNoTrackingAsync(CancellationToken cancellationToken)
        {
            return await _context.Features
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
