using FluentResults;
using Shared.Messages;

namespace Shared.Results.Successes.Default;

public class NoContentSuccess : Success
{
    public NoContentSuccess()
    {
        Message = StatusCodeMessageKeys.NoContentMessageKey;
    }
}