using FluentResults;
using Shared.Messages;

namespace Shared.Results.Errors.Default;

public sealed class InternalServerError(
    string? message = null) : Error(message ?? DefaultErrorMessageKeys.InternalServerErrorMessageKey)
{ }