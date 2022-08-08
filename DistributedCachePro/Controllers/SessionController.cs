using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DistributedCachePro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        public IActionResult Index()
        {
            var counter = HttpContext.Session.GetInt32("Counter01") ?? 0;
            counter++;
            HttpContext.Session.SetInt32("Counter01", counter);
            HttpContext.Session.CommitAsync();
            HttpContext.Response.WriteAsync($"The value of Counter01 is : {counter} \n\n");

            var sessionid = HttpContext.Session.Id;
            //object
            HttpContext.Session.Set<Person>("pp", new Person { id = 10, fullname = "ali" });
            HttpContext.Session.Set<Person>("ps", new Person { id = 11, fullname = "reza" });
            var pp = HttpContext.Session.Get<Person>("pp");
            var ps = HttpContext.Session.Get<Person>("ps");
            HttpContext.Response.WriteAsync($"The value of person is : {pp.ToString()} \n\n");
            HttpContext.Response.WriteAsync($"The value of person is : {ps.ToString()} \n\n");

            return Ok();
        }
    }
}
