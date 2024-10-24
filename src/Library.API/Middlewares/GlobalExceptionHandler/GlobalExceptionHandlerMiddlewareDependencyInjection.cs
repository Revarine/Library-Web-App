namespace Library.API.Middlewares.GlobalExceptionHandler;

public static class GlobalExceptionHandlerMiddlewareExtension
{
    public static void UseGlobalExceptionHandling(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
    }
}