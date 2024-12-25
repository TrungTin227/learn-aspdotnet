using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class HomeController : Controller
    {
        private readonly IRepository repository;

        //Các Controller trong ASP.NET Core MVC kế thừa từ ControllerBase
        //Các hàm public bên trong lớp controller chúng ta gọi là các action method
        //Các action method sẽ được gọi khi người dùng gửi URL request tới server(mà chúng ta đang chạy) và URL request đó phù hợp với pattern mà chúng ta đã định nghĩa trong Route
        //Quá trình map 1 URL vào trong 1 action method(controller)đẻ gọi nó thì  được gọi là routing
        //Cơ chế routing mặc định của ASP.NET Core MVC sẽ map URL theo dạng {controller=Home}/{action=Index}/{id?} (tên của controller/ rồi tên action method)
        private readonly ILogger<HomeController> _logger;

        public HomeController(IRepository repository ,ILogger<HomeController> logger)
        {
            this.repository = repository; //luôn có 1 Object Repository đc tạo mới mỗi khi gửi request tới server
            _logger = logger; //luôn có 1 Object Controller đc tạo mới mỗi khi gửi request tới server
        }
        //Action method Index sẽ trả về view Index
        public IActionResult Index()
        {
            return View(new HelloModel() { Name = "Trung Tin"});
        }
        //Action method Privacy sẽ trả về view Privacy
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult NewActionMethod(string name, int n)
        {
            return Content("Hi from new action method" + repository.GetById(name));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //Action method Error sẽ trả về view Error
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
