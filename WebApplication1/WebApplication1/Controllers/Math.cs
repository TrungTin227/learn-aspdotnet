using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class Math : Controller
    {
        public IActionResult Sum(int x, int y)
        {
            return Content((x + y).ToString());
        }
    }
}
