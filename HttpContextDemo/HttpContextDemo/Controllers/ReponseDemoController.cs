using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HttpContextDemo.Controllers
{
    public class ReponseDemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            Response.Headers.Append("X-Test-Header", "TestHeaderValue");
            return Ok("Test");
        }
    }
}
