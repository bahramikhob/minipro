using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DI.LifeTimes
{
    public class ScopeTestMiddleware
    {
        private readonly RequestDelegate _next;

        public ScopeTestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IScopeObject scopeObject01, IScopeObject scopeObject02)
        {

            await httpContext.Response.WriteAsync($"scopeObject02: " +
                $"{scopeObject01.GetId()}, scopeObject02: {scopeObject02.GetId()}\n\n");
            await _next(httpContext);
        }
    }
}
