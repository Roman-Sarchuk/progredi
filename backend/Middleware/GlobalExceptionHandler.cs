using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Progredi.Exceptions;

namespace Progredi.Middleware;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

        var statusCode = exception switch
        {
            AppException appEx => appEx.StatusCode,
            _ => StatusCodes.Status500InternalServerError 
        };

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = exception is AppException ? "Client Error" : "Server Error",
            Detail = exception.Message
        };

        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true; 
    }
}