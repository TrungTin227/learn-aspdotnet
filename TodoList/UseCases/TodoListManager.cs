using Entities;

namespace UseCases
{
    public class TodoListManager
    {
        private readonly ITodoItemRepository repository;

        public TodoListManager(ITodoItemRepository repository)
        {
            this.repository = repository;
        }
        public IEnumerable<TodoItem> GetTodoItems()
        {
            return repository.GetItems();
        }

        public void AddTodoItem(TodoItem item)
        {
            repository.Add(item);
        }

        public void MarkComplete(int id)
        {
            var item = repository.GetById(id);
            if (item != null)
            {
                item.IsComplete = true;
                repository.Update(item);
            }
            
        }

        public void Delete(int id)
        {
            repository.Delete(id);
           
        }

        
    }
}
