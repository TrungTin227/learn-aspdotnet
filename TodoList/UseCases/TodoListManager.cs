using Entities;

namespace UseCases
{
    public class TodoListManager(ITodoItemRepository repository)
    {
        private readonly ITodoItemRepository repository = repository;

        
        public IEnumerable<TodoItem> GetTodoItems()
        {
            return repository.GetItems();
        }

        public void AddTodoItem(TodoItem item)
        {
            repository.Add(item); // không cần biết được cách lưu trữ dữ liệu 
        }

        public void MarkComplete(int id)
        {
            var item = repository.GetById(id);
            if (item != null)
            {
                item.IsCompleted = true;
                repository.Update(item);
            }
            
        }
        public void Delete(int id)
        {
            repository.Delete(id);
           
        }
    }
}
