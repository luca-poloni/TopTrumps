using Application.Common.Interfaces;
using Domain.Common.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Interceptors
{
    internal sealed class AuditableEntityInterceptor(IUser user, TimeProvider timeProvider) : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            if (eventData.IsValid())
                UpdateEntities(eventData.Context);

            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            if (eventData.IsValid())
                UpdateEntities(eventData.Context);

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void UpdateEntities(DbContext? context)
        {
            if (context is null)
                return;

            var utcNow = timeProvider.GetUtcNow();

            foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = user.Id;
                        entry.Entity.Created = utcNow;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.DeletedBy = user.Id;
                        entry.Entity.Deleted = utcNow;
                        break;
                }

                entry.Entity.LastModifiedBy = user.Id;
                entry.Entity.LastModified = utcNow;
            }
        }
    }

    public static class Extensions
    {
        public static bool IsValid(this DbContextEventData? eventData) => eventData?.Context is not null;
    }
}
