using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Shared.Extensions;

namespace Api.Controllers.Utils;

public class CustomControllerBase : ControllerBase
{
    [NonAction]
    protected ActionResult CustomResult<T>(Result<T> result, string? location = null)
    {
        if (result.IsCreatedSuccess())
            return Created(location!, result.SuccessCustomResponse(HttpStatusCode.Created));

        if (result.IsNoContentSuccess() || result.IsEmptyResult())
            return NoContent();

        if (result.IsResourceNotFoundError())
            return NotFound(result.FailCustomResponse(HttpStatusCode.NotFound));

        if (result.IsServiceUnavailableError())
            return StatusCode(StatusCodes.Status503ServiceUnavailable, result.FailCustomResponse(HttpStatusCode.ServiceUnavailable));

        if (result.IsInternalServerError())
            return StatusCode(StatusCodes.Status500InternalServerError, result.FailCustomResponse(HttpStatusCode.InternalServerError));

        if (result.IsBadRequestError() || result.IsFailed)
            return BadRequest(result.FailCustomResponse(HttpStatusCode.BadRequest));

        return Ok(result.SuccessCustomResponse(HttpStatusCode.OK));
    }

    protected ActionResult CustomResult(Result result, string? location = null)
    {
        if (result.IsCreatedSuccess())
            return Created(location!, CustomResponseExtensions.SuccessCustomResponse(HttpStatusCode.Created));

        if (result.IsNoContentSuccess())
            return NoContent();

        if (result.IsResourceNotFoundError())
            return NotFound(result.FailCustomResponse(HttpStatusCode.NotFound));

        if (result.IsServiceUnavailableError())
            return StatusCode(StatusCodes.Status503ServiceUnavailable, result.FailCustomResponse(HttpStatusCode.ServiceUnavailable));

        if (result.IsInternalServerError())
            return StatusCode(StatusCodes.Status500InternalServerError, result.FailCustomResponse(HttpStatusCode.InternalServerError));

        if (result.IsBadRequestError() || result.IsFailed)
            return BadRequest(result.FailCustomResponse(HttpStatusCode.BadRequest));

        return Ok(CustomResponseExtensions.SuccessCustomResponse(HttpStatusCode.OK));
    }
}