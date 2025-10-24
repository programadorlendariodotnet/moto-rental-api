using FluentResults;
using Shared.Messages;

namespace Shared.Results.Successes.Default;

public class CreatedSuccess : Success
{
    public CreatedSuccess(int resourceId)
    {
        Metadata.Add("id", resourceId);
        Message = StatusCodeMessageKeys.CreatedMessageKey;
    }
}