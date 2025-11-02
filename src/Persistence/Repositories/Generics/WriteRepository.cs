using Domain.Contracts.Generics;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.Generics;

public class WriteRepository<T> : UnitOfWork, IWriteRepository<T> where T : class
{
    protected readonly WriteDataContext _context;
    protected readonly DbSet<T> _dbSet;

    public WriteRepository(WriteDataContext context) : base(context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await _dbSet.FindAsync(new object?[] { id }, cancellationToken);

    public virtual async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
        => await _dbSet.AddAsync(entity, cancellationToken);

    public virtual Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Update(entity);
        return Task.CompletedTask;
    }

    public virtual Task RemoveAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Remove(entity);
        return Task.CompletedTask;
    }
}