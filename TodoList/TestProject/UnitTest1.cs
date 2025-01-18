
using Entities;
using Infratructure;
using UseCases;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void CreateTodoItem_And_Set_Completed_Test()
        {
            var repository = new InMemoryTodoItemRepository();
            var manager = new TodoListManager(repository);
            var item = new TodoItem { Id = 1, Text = "Test", IsCompleted = false };
            manager.AddTodoItem(item);
            manager.MarkComplete(1);
            var items = manager.GetTodoItems();
            Assert.Single(items);
            Assert.Equal(item, items.First());
        }

    }
}