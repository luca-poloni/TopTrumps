using Ardalis.SharedKernel;
using Ardalis.Specification.EntityFrameworkCore;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class ApplicationRepository<T>(ApplicationDbContext dbContext) : RepositoryBase<T>(dbContext), IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot { }
}
