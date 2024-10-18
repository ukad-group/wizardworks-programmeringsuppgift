using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Wizardworks.Demo.Core.Infrastructure.Exceptions;

namespace Wizardworks.Demo.Core.Infrastructure.ExceptionHandling;
public class GlobalExceptionHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            var problemDetails = new ProblemDetails
            {
                Message = exception.Message,
                Status = StatusCodes.Status500InternalServerError,
            };

            switch (exception)
            {
                case ColorDuplicatedException or PositionDuplicatedException:
                    problemDetails.Status = StatusCodes.Status400BadRequest;
                    break;
                default:
                    problemDetails.Status = StatusCodes.Status500InternalServerError;
                    problemDetails.Message = "Something went wrong. Please contact administrator.";
                    break;
            }

            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = (int)problemDetails.Status!;

            await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
        }
    }
}
