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

            FileInfo file = new FileInfo("wwwroot/images/1.jpg");
            Response.ContentType = "text/html";
            Response.ContentLength = file.Length;

            using (var stream = file.OpenRead())
            {
                //var buffer = new byte[4096];
                //int bytesRead;
                //while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                //{
                //    Response.Body.Write(buffer, 0, bytesRead);
                //}
                //Dùng cách trên làm tốn bộ nhớ hơn khi đọc file lớn

                //Cách viết ngắn gọn hơn khi sử dụng stream và dùng CopyTo để copy từ stream này sang stream khác thông qua Response.Body

                stream.CopyTo(Response.Body);
            }


            return Ok("Test");
        }
    }
}
