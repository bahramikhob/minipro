using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SessionInMemoy
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


            //object
            HttpContext.Session.Set<Person>("pp", new Person { id = 10, fullname = "ali" });
            var pp = HttpContext.Session.Get<Person>("pp");
            HttpContext.Response.WriteAsync($"The value of person is : {pp.ToString()} \n\n");
           
            return Ok();
        }
    }
}
