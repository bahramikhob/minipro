using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace middleware
{
    public class ScMiddleware
    {
        private readonly RequestDelegate _next;

        public ScMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.Request.Query.ContainsKey("a") && httpContext.Request.Query["a"] == "1")
            {
                await _next(httpContext);
            }
            else
            {
                await httpContext.Response.WriteAsync("You can not use this application");
            }
        }
    }
}
