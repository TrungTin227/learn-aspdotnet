using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class Math : Controller
    {
        public IActionResult Sum(int x, int y)// public string Sum(int x, int y)
        {
            return Content((x + y).ToString());
        } // return (x + y).ToString();
        //nếu hàm action method trả về kiểu IActionResult thì nó sẽ trả về 1 view(Kiểu dữ liệu sẽ tùy chỉnh vào dữ liệu như var)
        //nếu kiểu trả về k phải kiểu IActionResult thì nó sẽ trả về kiểu mà chúng ta đã khai báo + ToString() nó sẽ gửi nguyên mẫu của kiểu dữ liệu đó về cho client
        //Trong thực tế ta sẽ không thường trực tiếp trả về 1 kiểu như int, string mà sẽ trả về  kiểu IActionResult
    }
}
