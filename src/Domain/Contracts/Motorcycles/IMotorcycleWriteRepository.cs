using Domain.Contracts.Motorcycles.Generics;
using Domain.Models.MotorcycleAggregate.Entities;

namespace Domain.Contracts.Motorcycles;

public interface IMotorcycleWriteRepository : IWriteRepository<Motorcycle>
{
    Task<Motorcycle?> GetByUIdAsync(string uId);
}
