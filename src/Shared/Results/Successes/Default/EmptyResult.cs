using FluentResults;
using Shared.Messages;

namespace Shared.Results.Successes.Default;

public class EmptyResult : Result
{
    public static Result GetResult()
    {
        return Ok().WithSuccess(StatusCodeMessageKeys.NoContentMessageKey);
    }
}