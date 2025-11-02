using FluentResults;
using MediatR;

namespace Application.Features.Motorcycles.Commands.CreateMotorcycle;

public sealed record CreateMotorcycleCommand(
    int Year,
    string Model,
    string Plate
) : IRequest<Result>;