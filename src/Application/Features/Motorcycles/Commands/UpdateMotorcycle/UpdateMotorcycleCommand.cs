using FluentResults;
using MediatR;

namespace Application.Features.Motorcycles.Commands.UpdateMotorcycle;

public sealed record UpdateMotorcycleCommand(
    string UId,
    string Plate
) : IRequest<Result>;