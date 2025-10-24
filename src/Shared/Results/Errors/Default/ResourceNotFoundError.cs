using FluentResults;
using Shared.Messages;

namespace Shared.Results.Errors.Default;

public class ResourceNotFoundError : Error
{
    public ResourceNotFoundError()
    {
        Message = StatusCodeMessageKeys.NotFoundMessageKey;
    }
}