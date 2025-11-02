using Domain.Contracts.DeliveryPersons;
using Domain.Models.DeliveryPersonAggregate.DTOs;
using Domain.Models.DeliveryPersonAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Generics;

namespace Persistence.Repositories.DeliveryPersons;

public class DeliveryPersonReadRepository : ReadRepository<DeliveryPerson>, IDeliveryPersonReadRepository
{
    public DeliveryPersonReadRepository(ReadDataContext context) : base(context)
    {
    }

    public async Task<DeliveryPersonDto?> GetByUIdAsync(string uId)
    {
        return await _dbSet
            .Where(d => d.UId.Value == uId)
            .Select(d => new DeliveryPersonDto(
                d.UId.Value,
                d.Name.Value,
                d.Cnpj.Value,
                d.BirthDate,
                d.CnhNumber.Value,
                d.CnhType.ToString(),
                d.CnhImageUrl != null ? d.CnhImageUrl.Value : null))
            .FirstOrDefaultAsync();
    }

    public async Task<List<DeliveryPersonDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Select(d => new DeliveryPersonDto(
                d.UId.Value,
                d.Name.Value,
                d.Cnpj.Value,
                d.BirthDate,
                d.CnhNumber.Value,
                d.CnhType.ToString(),
                d.CnhImageUrl != null ? d.CnhImageUrl.Value : null))
            .ToListAsync(cancellationToken);
    }
}
