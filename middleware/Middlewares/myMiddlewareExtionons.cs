using Microsoft.AspNetCore.Builder;

namespace middleware
{
    public static class myMiddlewareExtionons
    {
        public static IApplicationBuilder useMyMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<IPBlockMiddleware>();
            return app;
        }
    }

}
