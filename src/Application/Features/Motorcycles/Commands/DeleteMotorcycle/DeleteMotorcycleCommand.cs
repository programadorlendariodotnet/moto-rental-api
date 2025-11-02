using FluentResults;
using MediatR;

namespace Application.Features.Motorcycles.Commands.DeleteMotorcycle;

public sealed record DeleteMotorcycleCommand(string UId) : IRequest<Result>;