using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace middleware
{
    public class TerminatorMiddleware
    {
        private readonly RequestDelegate _next;

        public TerminatorMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("This is Terminator");
        }
    }

}
