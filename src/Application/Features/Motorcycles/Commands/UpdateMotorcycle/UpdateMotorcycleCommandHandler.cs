using Domain.Contracts.Motorcycles;
using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Motorcycles.Commands.UpdateMotorcycle;

public class UpdateMotorcycleCommandHandler(
    IMotorcycleWriteRepository motorcycleWriteRepository,
    ILogger<UpdateMotorcycleCommandHandler> logger
) : IRequestHandler<UpdateMotorcycleCommand, Result>
{
    public async Task<Result> Handle(UpdateMotorcycleCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("Executing command {CommandName}", nameof(UpdateMotorcycleCommandHandler));

        var motorcycle = await motorcycleWriteRepository.GetByUIdAsync(command.UId);
        if (motorcycle is null)
            return Result.Fail("Motorcycle not found");

        var plateExists = await motorcycleWriteRepository
            .AnyByPlateWithDiferentUIdAsync(command.Plate.ToLower(), command.UId);

        if (plateExists)
            return Result.Fail("Motorcycle plate already exists");

        var result = motorcycle.Update(command.Plate);
        if (result.IsFailed)
            return Result.Fail(result.Errors);

        await motorcycleWriteRepository.UpdateAsync(motorcycle, cancellationToken);
        await motorcycleWriteRepository.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Motorcycle plate updated successfully for {UId}", command.UId);

        return Result.Ok();
    }
}