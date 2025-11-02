using Domain.Contracts.Generics;
using Domain.Models.DeliveryPersonAggregate.Entities;

namespace Domain.Contracts.DeliveryPersons;

public interface IDeliveryPersonWriteRepository : IWriteRepository<DeliveryPerson>
{
    Task<DeliveryPerson?> GetByUIdAsync(string uId);
}
