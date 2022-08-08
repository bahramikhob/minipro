using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DI.LifeTimes
{
    public class TransientTestMiddleware
    {
        private readonly RequestDelegate _next;

        public TransientTestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ITransientObject transientObject01, ITransientObject transientObject02)
        {

            await httpContext.Response.WriteAsync($"transientObject01: " +
                $"{transientObject01.GetId()}, transientObject02: {transientObject02.GetId()}\n\n");
            await _next(httpContext);
        }
    }
}
