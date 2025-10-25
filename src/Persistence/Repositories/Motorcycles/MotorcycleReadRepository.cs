using Domain.Contracts.Motorcycles;
using Domain.Models.MotorcycleAggregate.DTOs;
using Domain.Models.MotorcycleAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Generics;

namespace Persistence.Repositories.Motorcycles;

public class MotorcycleReadRepository : ReadRepository<Motorcycle>, IMotorcycleReadRepository
{
    public MotorcycleReadRepository(ReadDataContext context) : base(context)
    {
    }

    public async Task<MotorcycleDto?> GetByUIdAsync(string uId)
    {
        return await _dbSet
            .Where(m => m.UId.Value == uId)
            .Select(m => new MotorcycleDto(m.UId.Value, m.Year, m.Model.Value, m.Plate.Value))
            .FirstOrDefaultAsync();
    }

    public async Task<List<MotorcycleDto>> GetAllByPlateAsync(string plate, CancellationToken cancellationToken)
    {
        return await _dbSet
            .Where(m => m.Plate.Value.ToLower() == plate.ToLower())
            .Select(m => new MotorcycleDto(
                m.UId.Value, 
                m.Year, 
                m.Model.Value, 
                m.Plate.Value))
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
