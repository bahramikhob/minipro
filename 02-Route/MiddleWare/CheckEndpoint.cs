namespace UrlRoutingSamples.Middleware;

public class CheckEndpoint
{
    private readonly RequestDelegate _next;

    public CheckEndpoint(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var endpoint = context.GetEndpoint();
        if(endpoint != null)
        {
            await context.Response.WriteAsync(endpoint.DisplayName);
        }
        if (_next != null)
            await _next(context);
    }
}

