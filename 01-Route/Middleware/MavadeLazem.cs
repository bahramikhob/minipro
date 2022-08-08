namespace _01_Route.Middleware
{
    public class MavadeLazem
    {
        private readonly RequestDelegate _next;

        public MavadeLazem(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            //www.eeee.com/mv/Nimroo
            //www.eeee.com/mv/Omlet
            //www.eeee.com/mv/NoonPanir
            var path = context.Request.Path.ToString();// /mv/Nimroo
            var pathSegments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            //pathSegments[0]=>mv
            //pathSegments[1]=>Nimroo
            string Str = string.Empty;
            if (pathSegments.Length == 2 && pathSegments[0] == "mv")
            {

                switch (pathSegments[1])
                {
                    case "Nimroo":
                        Str = "Roghan, Namak, Tokhme Morgh";
                        break;
                    case "Omlet":
                        Str = "Roghan, Namak, Tokhme Morgh, Goje";
                        break;
                    case "NoonPanir":
                        Str = "Noon, Panir";
                        break;
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
