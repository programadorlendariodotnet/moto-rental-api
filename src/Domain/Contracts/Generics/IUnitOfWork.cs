namespace Domain.Contracts.Generics;
public interface IUnitOfWork : IAsyncDisposable
{
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
}