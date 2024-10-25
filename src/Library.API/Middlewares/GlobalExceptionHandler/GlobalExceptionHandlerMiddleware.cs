using System.Net;
using System.Text.Json;

namespace Library.API.Middlewares.GlobalExceptionHandler;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var statusMessage = "Internal Server Error";

            if (exception is NullReferenceException)
            {
                statusCode = HttpStatusCode.NotFound;
                statusMessage = "Not found :c";
            }

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            var errorResponse = new { Message = exception.Message, StatusMessage = statusMessage };

            var result = JsonSerializer.Serialize(errorResponse);
            await context.Response.WriteAsync(result);
        }
    }
}