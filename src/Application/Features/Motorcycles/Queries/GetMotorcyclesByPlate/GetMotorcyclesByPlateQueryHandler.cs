using Domain.Contracts.Motorcycles;
using Domain.Models.MotorcycleAggregate.DTOs;
using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Motorcycles.Queries.GetMotorcyclesByPlate;

public class GetMotorcyclesByPlateQueryHandler(
    IMotorcycleReadRepository motorcycleReadRepository,
    ILogger<GetMotorcyclesByPlateQueryHandler> logger
) : IRequestHandler<GetMotorcyclesByPlateQuery, Result<List<MotorcycleDto>>>
{
    public async Task<Result<List<MotorcycleDto>>> Handle(
        GetMotorcyclesByPlateQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("Executing query {QueryName}", nameof(GetMotorcyclesByPlateQueryHandler));

        var motorcycles = await motorcycleReadRepository.GetAllByPlateAsync(query.PlateFilter ?? "", cancellationToken);

        logger.LogInformation("Query {QueryName} executed successfully", nameof(GetMotorcyclesByPlateQueryHandler));

        return Result.Ok(motorcycles);
    }
}