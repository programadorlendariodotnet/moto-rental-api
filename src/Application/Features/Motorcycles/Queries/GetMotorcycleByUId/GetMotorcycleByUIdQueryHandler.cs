using Domain.Contracts.Motorcycles;
using Domain.Models.MotorcycleAggregate.DTOs;
using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Motorcycles.Queries.GetMotorcycleByUId;

public class GetMotorcycleByUIdQueryHandler(
    IMotorcycleReadRepository motorcycleReadRepository,
    ILogger<GetMotorcycleByUIdQueryHandler> logger
) : IRequestHandler<GetMotorcycleByUIdQuery, Result<MotorcycleDto>>
{
    public async Task<Result<MotorcycleDto>> Handle(
        GetMotorcycleByUIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("Executing query {QueryName}", nameof(GetMotorcycleByUIdQueryHandler));

        var motorcycle = await motorcycleReadRepository.GetByUIdAsync(query.UId);

        if (motorcycle is null)
        {
            logger.LogWarning("Motorcycle not found for UId: {UId}", query.UId);
            return Result.Fail("Motorcycle not found");
        }

        logger.LogInformation("Query {QueryName} executed successfully", nameof(GetMotorcycleByUIdQueryHandler));

        return Result.Ok(motorcycle);
    }
}