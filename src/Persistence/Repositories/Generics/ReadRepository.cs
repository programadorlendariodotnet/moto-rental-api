using Domain.Contracts.Generics;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.Generics;

public class ReadRepository<T> : IReadRepository<T> where T : class
{
    protected readonly ReadDataContext _context;
    protected readonly DbSet<T> _dbSet;

    public ReadRepository(ReadDataContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await _dbSet.FindAsync(new object?[] { id }, cancellationToken);
}