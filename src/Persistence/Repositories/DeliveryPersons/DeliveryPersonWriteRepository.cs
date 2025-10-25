using Domain.Contracts.DeliveryPersons;
using Domain.Models.DeliveryPersonAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Generics;

namespace Persistence.Repositories.DeliveryPersons;

public class DeliveryPersonWriteRepository : WriteRepository<DeliveryPerson>, IDeliveryPersonWriteRepository
{
    public DeliveryPersonWriteRepository(WriteDataContext context) : base(context)
    {
    }

    public async Task<DeliveryPerson?> GetByUIdAsync(string uId)
    {
        return await _dbSet
            .FirstOrDefaultAsync(d => d.UId.Value == uId);
    }
}
