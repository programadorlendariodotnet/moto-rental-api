namespace Domain.Contracts.Motorcycles.Generics;

public interface IReadRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}