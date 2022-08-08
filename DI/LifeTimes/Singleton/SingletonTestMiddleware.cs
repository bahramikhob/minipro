using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DI.LifeTimes
{
    public class SingletonTestMiddleware
    {
        private readonly RequestDelegate _next;

        public SingletonTestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ISingletonObject singletonObject01, ISingletonObject singletonObject02)
        {

            await httpContext.Response.WriteAsync($"singletoneObject01: " +
                $"{singletonObject01.GetId()}, singletonObject02: {singletonObject02.GetId()}\n\n");
            await _next(httpContext);
        }
    }
}
