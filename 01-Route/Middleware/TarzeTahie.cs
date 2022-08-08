namespace _01_Route.Middleware
{
    public class TarzeTahie
    {
        private readonly RequestDelegate _next;

        public TarzeTahie(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //www.eeee.com/tt/Nimroo
            //www.eeee.com/tt/Omlet
            //www.eeee.com/tt/NoonPanir

            //www.eeee.com/tt/Kotlet

            var path = context.Request.Path.ToString();
            var pathSegments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            string Str = string.Empty;
            if (pathSegments.Length == 2 && pathSegments[0] == "tt")
            {
                switch (pathSegments[1])
                {
                    case "Nimroo":
                        Str = "Roghan+Namak+Tokhme Morgh";
                        break;
                    case "Omlet":
                        Str = "Roghan+Namak+Tokhme Morgh+Goje";
                        break;
                    case "NoonPanir":
                        Str = "Noon+Panir";
                        break;
                    case "Kotlet":
                        context.Response.Redirect("/mv/Nimroo");
                        return;
                }
                if (!string.IsNullOrEmpty(Str))
                {
                    context.Response.ContentType = "text/html";
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync(Str);
                }
            }
            if (_next != null)
                await _next(context);
        }
    }


}
