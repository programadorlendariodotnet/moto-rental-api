using Domain.Contracts.Generics;
using Domain.Models.DeliveryPersonAggregate.DTOs;
using Domain.Models.DeliveryPersonAggregate.Entities;

namespace Domain.Contracts.DeliveryPersons;

public interface IDeliveryPersonReadRepository : IReadRepository<DeliveryPerson>
{
    Task<DeliveryPersonDto?> GetByUIdAsync(string uId);
    Task<List<DeliveryPersonDto>> GetAllAsync(CancellationToken cancellationToken = default);
}
