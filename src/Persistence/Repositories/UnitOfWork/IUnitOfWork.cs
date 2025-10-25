namespace Persistence.Repositories.UnitOfWork;

public interface IUnitOfWork : IAsyncDisposable
{
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}