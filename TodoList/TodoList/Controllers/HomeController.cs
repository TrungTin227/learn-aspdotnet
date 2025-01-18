using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoList.Models;
using UseCases;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        //Controller ch? c?n quan tâm làm soa ?? l?y ???c d? li?u và b? nào trong model ?ó
        private readonly TodoListManager _listManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(TodoListManager listManager, ILogger<HomeController> logger)
        {
            _listManager = listManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var todoItems = _listManager.GetTodoItems();
            return View(new TodoListViewModel()
            {
                Items = todoItems.Select(item => new TodoItem()
                {
                    Id = item.Id,
                    Text = item.Text,
                    IsCompleted = item.IsCompleted
                }).ToList()
            });
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public IActionResult Add(Item item)
        {
            _listManager.AddTodoItem(new TodoItem()
            {
                Id = item.Id,
                Text = item.Text,
                IsCompleted = false
            });
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MaskComplete(int[] completedItems) //Có thể hoàn thành nhiều công việc cùng lúc nên chỗ nãy phải là 1 mảng chứ không phải 1 biến bình thường
        {
            
            if(completedItems == null || completedItems.Length == 0)
            {
                return RedirectToAction("Index");
            }    
                foreach (var i in completedItems)
                {
                    _listManager.MarkComplete(i);
                }
            
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
