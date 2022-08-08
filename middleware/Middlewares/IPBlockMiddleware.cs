using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace middleware
{
    public class IPBlockMiddleware
    {
        private RequestDelegate _next;
        private readonly IConfiguration configuration;
        private readonly ILogger<IPBlockMiddleware> _logger;

        public IPBlockMiddleware(RequestDelegate next, IConfiguration _configuration, ILogger<IPBlockMiddleware> logger)
        {
            _next = next;
            configuration = _configuration;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            //var remoteIp = httpContext.Connection.RemoteIpAddress

            //if (context.Request.Method != HttpMethod.Get.Method)
            // {
            var remoteIp = context.Connection.RemoteIpAddress;
            _logger.LogDebug("Request from Remote IP address: {RemoteIp}", remoteIp);

            string[] ip = configuration["AdminSafeList"].Split(';');

            var bytes = remoteIp.GetAddressBytes();
            var badIp = true;
            foreach (var address in ip)
            {
                var testIp = IPAddress.Parse(address);
                if (testIp.GetAddressBytes().SequenceEqual(bytes))
                {
                    badIp = false;
                    break;
                }
            }

            if (badIp)
            {
                _logger.LogWarning(
                    "Forbidden Request from Remote IP address: {RemoteIp}", remoteIp);
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                return;
            }
            // }



            await _next.Invoke(context);

            context.Response.StatusCode = 400;


        }
    }

}
