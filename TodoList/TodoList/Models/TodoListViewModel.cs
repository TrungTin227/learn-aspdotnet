namespace TodoList.Models
{
    public class TodoListViewModel
    {
        //Chỉ cẩn quan tâm cấu trúc dữ liệu chạy bên trong đó là gì
        public required IEnumerable<TodoItem> Items { get; init; } //Chỉ cho phép đặt lại giá trị khi new 1 object thuộc lớp này
    }
}
