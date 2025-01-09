using HttpContextDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HttpContextDemo.Helpers;

namespace HttpContextDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //HttpContext.Request được implement trong Controller base class vì vậy không cần thêm bất kỳ thư viện nào vd: HttpContext.Request hoặc viết ngắn gọn là Request
            //_logger.LogInformation("ID {id} from {sch}://{host}", HttpContext.TraceIdentifier, Request.Scheme, Request.Host);
            //Dài dòng nên khai báo riêng 1 hàm ở dưới
            _logger.LogInformation("ID {id} from {host}", HttpContext.TraceIdentifier, Request.GetDebugInfo());
            return View();
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
