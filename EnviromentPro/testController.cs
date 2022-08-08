using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnviromentPro
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
        private readonly TestService testService;
        private readonly sitesetting1 sitesetting;
        private readonly ILogger<testController> logger;

        public testController(TestService testService, sitesetting1 sitesetting, ILogger<testController> logger)
        {
            this.testService = testService;
            this.sitesetting = sitesetting;
            this.logger = logger;
        }
        public IActionResult get()
        {            
            var site = sitesetting.sitename;
            testService.Get();

            return Ok("jjjj");
        }
    }
}
