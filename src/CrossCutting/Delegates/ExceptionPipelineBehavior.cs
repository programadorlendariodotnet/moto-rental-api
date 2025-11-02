using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;
using Shared.Results.Errors.Default;

namespace CrossCutting.Delegates;

public class ExceptionPipelineBehavior<TRequest, TResponse>(
    ILogger<ExceptionPipelineBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : ResultBase, new()
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An unexpected error occurred");

            var response = new TResponse();
            response.Reasons.Add(new InternalServerError("An unexpected error occurred, please try again later."));

            return response;
        }
    }
}