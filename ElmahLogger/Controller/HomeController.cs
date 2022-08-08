using ElmahCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElmahLogger
{
    [ApiController]
    [Route(template:"api/[Controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            //elmah not save log  biulting Logger asp core
            _logger.LogTrace("log info {0}", "Trace");
            _logger.LogDebug("log info {0}", "Debug");
            _logger.LogInformation("log info {0}", "information");
            _logger.LogWarning("log info {0}", "Warning");
            _logger.LogError("log info {0}", "Error");
            _logger.LogCritical("log info {0}", "Critical");

            throw new Exception("نام کاربری یا رمز عبور اشتباه است");

            HttpContext.RiseError(new Exception("متد Create فراخوانی شد"));
            HttpContext.RiseError(new InvalidOperationException("Test"));


            return Ok();
        }
    }
}
