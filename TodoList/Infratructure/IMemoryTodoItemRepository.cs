using Entities;
using UseCases;

namespace Infratructure
{
    public class IMemoryTodoItemRepository : ITodoItemRepository
    {
        private List<TodoItem> items = new List<TodoItem>();
        public void Add(TodoItem item)
        {
            items.Add(item);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                items.Remove(item);
            }
        }

        public TodoItem? GetById(int id)
        {
            return items.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<TodoItem> GetItems()
        {
            return items;
        }

        public void Update(TodoItem item)
        {
            var existingItem = GetById(item.Id);
            if (existingItem != null)
            {
                existingItem.Text = item.Text;
                existingItem.IsComplete = item.IsComplete;
            }
        }
    }
} 
