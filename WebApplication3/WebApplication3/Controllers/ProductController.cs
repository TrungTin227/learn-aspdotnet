using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("p/{id:int}")]
        //[Route("product/{id}")] // dùng ho việc định nghĩa nhiều route cho một action

        public IActionResult Details(int id)
        {
            return View(new Product()
            {
                Id = id.ToString(),
                Name = $"Product Name: {id} (int)"
            });
        }

        [Route("p/{name}")]
        public IActionResult Details(string name)
        {
            return View(new Product()
            {
                Id = name,
                Name = $"Product Name: {name} (string)"
            });
        }
    }
}
