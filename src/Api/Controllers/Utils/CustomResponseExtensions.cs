using FluentResults;
using System.Net;

namespace Api.Controllers.Utils;

public static class CustomResponseExtensions
{
    public static CustomResponseDto FailCustomResponse<T>(this Result<T> result, HttpStatusCode httpStatusCode) =>
        BuildCustomResponse(false, httpStatusCode, null, BuildErrorMessageList(result.Errors));

    public static CustomResponseDto FailCustomResponse(this Result result, HttpStatusCode httpStatusCode) =>
        BuildCustomResponse(false, httpStatusCode, null, BuildErrorMessageList(result.Errors));

    public static CustomResponseDto SuccessCustomResponse<T>(this Result<T> result, HttpStatusCode httpStatusCode) =>
        BuildCustomResponse(true, httpStatusCode, result.Value, []);

    public static CustomResponseDto SuccessCustomResponse(HttpStatusCode httpStatusCode) =>
        BuildCustomResponse(true, httpStatusCode, null, []);

    private static CustomResponseDto BuildCustomResponse(bool success, HttpStatusCode statusCode, object? data,
        List<string> errors) => new(success, (int)statusCode, data, errors, DateTimeOffset.UtcNow);

    private static List<string> BuildErrorMessageList(List<IError> resultErrorList)
    {
        var errorList = resultErrorList.Select(error => error.Message).ToList();
        return errorList;
    }
}