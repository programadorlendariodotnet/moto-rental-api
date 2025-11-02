using Domain.Contracts.Motorcycles;
using Domain.Contracts.Rentals;
using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Motorcycles.Commands.DeleteMotorcycle;

public class DeleteMotorcycleCommandHandler(
    IMotorcycleWriteRepository motorcycleWriteRepository,
    IRentalReadRepository rentalReadRepository,
    ILogger<DeleteMotorcycleCommandHandler> logger
) : IRequestHandler<DeleteMotorcycleCommand, Result>
{
    public async Task<Result> Handle(DeleteMotorcycleCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("Executing command {CommandName}", nameof(DeleteMotorcycleCommandHandler));

        var motorcycle = await motorcycleWriteRepository.GetByUIdAsync(command.UId);
        if (motorcycle is null)
        {
            logger.LogWarning("Motorcycle not found for UId: {UId}", command.UId);
            return Result.Fail("Motorcycle not found");
        }

        var hasRental = await rentalReadRepository
            .AnyByMotorcycleIdAsync(motorcycle.Id, cancellationToken);

        if (hasRental)
        {
            logger.LogWarning("Cannot delete motorcycle with active rentals. UId: {UId}", command.UId);
            return Result.Fail("Motorcycle has active rentals");
        }

        await motorcycleWriteRepository.RemoveAsync(motorcycle, cancellationToken);
        await motorcycleWriteRepository.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Motorcycle {UId} deleted successfully", command.UId);

        return Result.Ok();
    }
}