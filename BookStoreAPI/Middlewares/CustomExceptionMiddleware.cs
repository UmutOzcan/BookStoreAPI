using System.Diagnostics;
using System.Net;
namespace BookStoreAPI.Middlewares;

public class CustomExceptionMiddleware // Middleware
{
    private readonly RequestDelegate _next;

    public CustomExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        var watch = Stopwatch.StartNew(); // calisma suresi baslatir

        try
        {
            string message = "[Request]  HTTP " + httpContext.Request.Method + " - " + httpContext.Request.Path;
            Console.WriteLine(message);

            await _next(httpContext); // middleware tamamlanır
            watch.Stop(); // Request - Response suresi tutar

            message = "[Response] HTTP " + httpContext.Request.Method + " - " + httpContext.Request.Path + " responded " + httpContext.Response.StatusCode + " in "
                + watch.ElapsedMilliseconds + "ms";
            Console.WriteLine(message);
        }
        catch (Exception ex) // Eger fluentvalidation ile bi exception throw edilirse handle et
        {
            watch.Stop();
            await HandleException(httpContext,ex,watch); // Handle fonksiyonuna yonlendir
        }
    }

    private Task HandleException(HttpContext httpContext, Exception ex, Stopwatch watch)
    {
        string message = "[Error]    HTTP " + httpContext.Request.Method + " - " + httpContext.Response.StatusCode + " Error Message " + ex.Message + " in "
            + watch.ElapsedMilliseconds + "ms";
        Console.WriteLine(message);

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var result = System.Text.Json.JsonSerializer.Serialize(new
        {
            error = ex.Message,
        });

        return httpContext.Response.WriteAsync(result);
    }
}

public static class CustomExceptionMiddlewareExtension // Extension methodu
{
    public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomExceptionMiddleware>();
    }
}
