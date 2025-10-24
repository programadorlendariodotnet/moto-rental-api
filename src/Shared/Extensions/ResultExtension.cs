using FluentResults;
using Shared.Messages;
using Shared.Results.Errors.Base;
using Shared.Results.Errors.Default;
using Shared.Results.Successes.Default;

namespace Shared.Extensions;

/// <summary>
/// Extension for FluentResult
/// </summary>
public static class ResultExtension
{
    public static bool IsCreatedSuccess(this ResultBase result)
    {
        return result.HasSuccess<CreatedSuccess>();
    }

    public static bool IsNoContentSuccess(this ResultBase result)
    {
        return result.HasSuccess<NoContentSuccess>();
    }

    public static bool IsEmptyResult<T>(this Result<T> result)
    {
        return result.IsSuccess
               && (result.Value is null
                   || result.HasSuccess(x => x.Message.Equals(StatusCodeMessageKeys.NoContentMessageKey)));
    }

    public static bool IsResourceNotFoundError(this ResultBase result)
    {
        return result.HasError<ResourceNotFoundError>();
    }

    public static bool IsBadRequestError(this ResultBase result)
    {
        return result.HasError<BadRequestFieldsError>();
    }
    
    public static bool IsServiceUnavailableError(this ResultBase result)
    {
        return result.HasError<ServiceUnavailableError>();
    }

    public static bool IsInternalServerError(this ResultBase result)
    {
        return result.HasError<InternalServerError>();
    }
}