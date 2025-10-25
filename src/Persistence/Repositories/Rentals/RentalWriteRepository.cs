using Domain.Contracts.Rentals;
using Domain.Models.RentalAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Generics;

namespace Persistence.Repositories.Rentals;

public class RentalWriteRepository : WriteRepository<Rental>, IRentalWriteRepository
{
    public RentalWriteRepository(WriteDataContext context) : base(context)
    {
    }

    public async Task<Rental?> GetByUIdAsync(string uId)
    {
        return await _dbSet
            .FirstOrDefaultAsync(r => r.UId.Value == uId);
    }
}