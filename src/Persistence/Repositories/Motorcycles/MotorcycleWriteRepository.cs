using Domain.Contracts.Motorcycles;
using Domain.Models.MotorcycleAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Generics;

namespace Persistence.Repositories.Motorcycles;

public class MotorcycleWriteRepository : WriteRepository<Motorcycle>, IMotorcycleWriteRepository
{
    public MotorcycleWriteRepository(WriteDataContext context) : base(context)
    {
    }

    public async Task<Motorcycle?> GetByUIdAsync(string uId)
    {
        return await _dbSet
            .Where(m => m.UId.Value == uId)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> AnyByPlateAsync(string plate)
    {
        return await _dbSet
            .AnyAsync(m => m.Plate.Value.ToLower() == plate.ToLower());
    }

    public async Task<bool> AnyByPlateWithDiferentUIdAsync(string plate, string uId)
    {
        return await _dbSet
            .AnyAsync(m => m.Plate.Value.ToLower() == plate.ToLower() && m.UId.Value != uId);
    }
}