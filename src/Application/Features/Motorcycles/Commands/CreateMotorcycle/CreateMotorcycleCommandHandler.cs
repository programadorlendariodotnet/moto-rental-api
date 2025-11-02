using Domain.Contracts.Motorcycles;
using Domain.Models.MotorcycleAggregate.Entities;
using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;
using Shared.Results.Successes.Default;

namespace Application.Features.Motorcycles.Commands.CreateMotorcycle;

public class CreateMotorcycleCommandHandler(
    IMotorcycleWriteRepository motorcycleWriteRepository,
    ILogger<CreateMotorcycleCommandHandler> logger
) : IRequestHandler<CreateMotorcycleCommand, Result>
{
    public async Task<Result> Handle(CreateMotorcycleCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("Executing command {CommandName}", nameof(CreateMotorcycleCommandHandler));

        var exists = await motorcycleWriteRepository
            .AnyByPlateAsync(command.Plate);

        if (exists)
            return Result.Fail("Motorcycle already exists");

        var motorcycleResult = Motorcycle
            .Create(Ulid.NewUlid().ToString(), command.Year, command.Model, command.Plate);

        if (motorcycleResult.IsFailed)
            return Result.Fail(motorcycleResult.Errors);

        await motorcycleWriteRepository.CreateAsync(motorcycleResult.Value, cancellationToken);
        await motorcycleWriteRepository.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Command {CommandName} Executed Successfully", nameof(CreateMotorcycleCommandHandler));

        return Result.Ok().WithSuccess(new CreatedSuccess(motorcycleResult.Value.Id));
    }
}