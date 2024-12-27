using Entities;

namespace TodoList.Models
{
    public class TodoListViewModel
    {
        public required IEnumerable<TodoItem> Items { get; init; } //cho nay dung init vi khong muon thay doi gia tri cua Items sau khi khoi tao
    }
}
