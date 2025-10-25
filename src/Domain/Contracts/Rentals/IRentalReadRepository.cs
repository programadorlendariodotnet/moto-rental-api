﻿using Domain.Contracts.Motorcycles.Generics;
using Domain.Models.RentalAggregate.DTOs;
using Domain.Models.RentalAggregate.Entities;

namespace Domain.Contracts.Rentals;

public interface IRentalReadRepository : IReadRepository<Rental>
{
    Task<RentalDto?> GetByUIdAsync(string uId);
    Task<List<RentalDto>> GetAllAsync(CancellationToken cancellationToken = default);
}
