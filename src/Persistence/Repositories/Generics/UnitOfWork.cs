using Domain.Contracts.Generics;
using Persistence.Context;

namespace Persistence.Repositories.Generics;

public class UnitOfWork(WriteDataContext context) : IUnitOfWork
{
    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await context.SaveChangesAsync(cancellationToken) > 0;

    public async ValueTask DisposeAsync()
    {
        await context.DisposeAsync();
    }
}