using Domain.Models.MotorcycleAggregate.DTOs;
using FluentResults;
using MediatR;

namespace Application.Features.Motorcycles.Queries.GetMotorcyclesByPlate;

public sealed record GetMotorcyclesByPlateQuery(string? PlateFilter = null)
    : IRequest<Result<List<MotorcycleDto>>>;