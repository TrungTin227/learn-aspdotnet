using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class CollectionController : Controller
    {
        public IActionResult Index(string id)
        {
            //return View("Index", id);
            return View((object)id);
        }
    }
}
