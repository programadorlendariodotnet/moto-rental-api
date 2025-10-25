﻿using Domain.Contracts.Motorcycles.Generics;
using Domain.Models.RentalAggregate.Entities;

namespace Domain.Contracts.Rentals;

public interface IRentalWriteRepository : IWriteRepository<Rental>
{
    Task<Rental?> GetByUIdAsync(string uId);
}