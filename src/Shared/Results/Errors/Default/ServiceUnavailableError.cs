using FluentResults;
using Shared.Messages;

namespace Shared.Results.Errors.Default;

public class ServiceUnavailableError : Error
{
    public ServiceUnavailableError()
    {
        Message = DefaultErrorMessageKeys.ServiceUnavailableMessageKey;
    }
}