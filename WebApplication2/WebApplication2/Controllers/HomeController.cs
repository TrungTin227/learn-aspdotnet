using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    //Khi thêm 1 hàm public (instance) vào trong Controller thì nó sẽ trở thành 1 Action method
    //Action method là 1 phương thức public mà có thể được gọi từ client
    // [NonController] // This class will not be treated as a controller không thể truy cập vào các action method
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //[NonAction] // This action will not be accessible 

        public IActionResult Contact()
        {
            return View();
        }
        //[HttpGet] // Method Get mới được dùng để gọi action method này    
        //Lấy chính xác tham số truyền vào là QueryString, nếu tham số khác thì không nhận, còn nếu không khai báo gì thì sẽ tùy vào method gọi đến action method này
        //public IActionResult Users([FromForm] string myParam, [FromHeader] string apikey)
        //{
        //    //Cho dù ta có gọi mới action method nào (get, post, ...) thì action method này đều đc gọi
        //    _logger.LogInformation("[Users] METHOD: {m}, myParam = {p}, apikey = {apikey}", Request.Method, myParam, apikey);
        //    return Content("Users: " + myParam + " apikey = " + apikey);
        //}
        private void ValidateApiKey(string apikey)
        {
           if(apikey == null)
           {
                throw new Exception("API key is required");
           }    
        }
        [HttpGet]
        [Route("/api/users")] // Cho phép chỉ dẫn tới action method này mà không cần phải gõ tên controller
        //Cho phép map url vào Action Method tưởng ứng 
        public IActionResult Users([FromHeader] string apikey, [FromServices]IUserRepository userRepository)
        {
            
            _logger.LogInformation("[Users] METHOD: {m}, apikey = {apikey}", Request.Method, apikey);
            ValidateApiKey(apikey);
            return Content($"Users: {string.Join(',', userRepository.Users)}");
        }


        [HttpPost]
        [Route("/api/users")]
        public IActionResult Users([FromHeader] string apikey, [FromServices] IUserRepository userRepository, [FromForm]string user)
        {
            _logger.LogInformation("[Users] METHOD: {m}, apikey = {apikey}", Request.Method, apikey);
            ValidateApiKey(apikey);
            userRepository.Add(user);
            return Ok();
        }

        //[HttpPost] // Method Post mới được dùng để gọi action method này

        //public IActionResult Users(string user)
        //{
        //    //Cho dù ta có gọi mới action method nào (get, post, ...) thì action method này đều đc gọi
        //    _logger.LogInformation("[Users] METHOD: {m}", Request.Method);
        //    return Content("User added: " + user);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
