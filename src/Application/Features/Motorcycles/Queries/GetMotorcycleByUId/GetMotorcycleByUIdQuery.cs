using Domain.Models.MotorcycleAggregate.DTOs;
using FluentResults;
using MediatR;

namespace Application.Features.Motorcycles.Queries.GetMotorcycleByUId;

public sealed record GetMotorcycleByUIdQuery(string UId)
    : IRequest<Result<MotorcycleDto>>;