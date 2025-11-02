using Domain.Contracts.Generics;
using Domain.Models.MotorcycleAggregate.DTOs;
using Domain.Models.MotorcycleAggregate.Entities;

namespace Domain.Contracts.Motorcycles;

public interface IMotorcycleReadRepository : IReadRepository<Motorcycle>
{
    Task<List<MotorcycleDto>> GetAllByPlateAsync(string plateFilter, CancellationToken cancellationToken = default);
    Task<MotorcycleDto?> GetByUIdAsync(string uId);
}
