using Domain.Contracts.Generics;
using Domain.Models.MotorcycleAggregate.Entities;

namespace Domain.Contracts.Motorcycles;

public interface IMotorcycleWriteRepository : IWriteRepository<Motorcycle>
{
    Task<Motorcycle?> GetByUIdAsync(string uId);
    Task<bool> AnyByPlateAsync(string plate);
    Task<bool> AnyByPlateWithDiferentUIdAsync(string plate, string uId);
}