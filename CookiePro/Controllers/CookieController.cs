using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaticFiles.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CookieController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieController(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            //read cookie from IHttpContextAccessor  
            string cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies["counter1"];
            //read cookie from Request object  
            string cookieValueFromReq = Request.Cookies["counter1"];
            //set the key value in Cookie  
            //Set("Key", "Hello from cookie", 10);

            int counter1 = int.Parse(HttpContext.Request.Cookies["counter1"] ?? "0") + 1;



            //Set in cookie
            HttpContext.Response.Cookies.Append("counter1", counter1.ToString(),
            new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(10),
               // IsEssential = true,
                MaxAge = TimeSpan.FromMinutes(30),
                HttpOnly=true

            });


            //Delete the cookie object  
            //Remove("Key");
            return Ok();
        }

        /// <summary>  
        /// Get the cookie  
        /// </summary>  
        /// <param name="key">Key </param>  
        /// <returns>string value</returns>
        [NonAction]
        public string Get(string key)
        {
            return Request.Cookies[key];
        }
        /// <summary>  
        /// set the cookie  
        /// </summary>  
        /// <param name="key">key (unique indentifier)</param>  
        /// <param name="value">value to store in cookie object</param>  
        /// <param name="expireTime">expiration time</param>  
        [NonAction]
        public void Set(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();
            if (expireTime.HasValue)
            {
                option.MaxAge = TimeSpan.FromMinutes(30);
                // option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
                // option.HttpOnly = true;

            }
            else
            {
                option.Expires = DateTime.Now.AddMilliseconds(10);
            }
            Response.Cookies.Append(key, value, option);
        }
        /// <summary>  
        /// Delete the key  
        /// </summary>  
        /// <param name="key">Key</param>  
        [NonAction]
        public void Remove(string key)
        {
            Response.Cookies.Delete(key);
        }

    }
}

