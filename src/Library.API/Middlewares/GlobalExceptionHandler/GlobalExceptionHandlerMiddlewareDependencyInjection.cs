namespace Library.API.Middlewares.GlobalExceptionHandler;

public static class GlobalExceptionHandlerMiddlewareDependencyInjection
{
    public static void UseGlobalExceptionHandling(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
    }
}