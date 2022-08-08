using ElmahCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoggerController : ControllerBase
    {
        private readonly ILogger<LoggerController> _logger;

        public LoggerController(ILogger<LoggerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            _logger.LogTrace("log info {0}", "Trace");
            _logger.LogDebug("log info {0}", "Debug");
            _logger.LogInformation("log info {0}", "information");
            _logger.LogWarning("log info {0}", "Warning");
            _logger.LogError("log info {0}", "Error");
            _logger.LogCritical("log info {0}", "Critical");
           
            HttpContext.RiseError(new Exception("متد Create فراخوانی شد"));
            HttpContext.RiseError(new InvalidOperationException("Test"));

            throw new Exception("نام کاربری یا رمز عبور اشتباه است");

            return Ok();
        }
    }
}
