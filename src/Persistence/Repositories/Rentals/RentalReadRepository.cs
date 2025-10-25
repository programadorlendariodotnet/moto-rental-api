using Domain.Contracts.Rentals;
using Domain.Models.RentalAggregate.DTOs;
using Domain.Models.RentalAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Generics;

namespace Persistence.Repositories.Rentals;

public class RentalReadRepository : ReadRepository<Rental>, IRentalReadRepository
{
    public RentalReadRepository(ReadDataContext context) : base(context)
    {
    }

    public async Task<RentalDto?> GetByUIdAsync(string uId)
    {
        return await _dbSet
            .Where(r => r.UId.Value == uId)
            .Select(r => new RentalDto(
                r.UId.Value,
                r.DeliveryPersonId.ToString(),
                r.MotorcycleId.ToString(),
                r.StartDate,
                r.ExpectedEndDate,
                r.EndDate,
                r.Days,
                r.DailyRate,
                r.TotalAmount))
            .FirstOrDefaultAsync();
    }

    public async Task<List<RentalDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Select(r => new RentalDto(
                r.UId.Value,
                r.DeliveryPersonId.ToString(),
                r.MotorcycleId.ToString(),
                r.StartDate,
                r.ExpectedEndDate,
                r.EndDate,
                r.Days,
                r.DailyRate,
                r.TotalAmount))
            .ToListAsync(cancellationToken);
    }
}
