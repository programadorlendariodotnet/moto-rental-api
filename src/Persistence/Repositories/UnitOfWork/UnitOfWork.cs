using Persistence.Context;

namespace Persistence.Repositories.UnitOfWork;

public class UnitOfWork(WriteDataContext context) : IUnitOfWork
{
    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        => await context.SaveChangesAsync(cancellationToken);

    public async ValueTask DisposeAsync()
    {
        await context.DisposeAsync();
    }
}