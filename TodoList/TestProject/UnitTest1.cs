
using Entities;
using Infratructure;
using UseCases;

namespace TestProject
{
    public class UnitTest1
    { 

        [Fact]
        public void AddTodoItem_ShouldAddItem()
        {
            // Arrange
            var mockRepository = new IMemoryTodoItemRepository();
            var newItem = new TodoItem { Id = 4, Text = "New Task", IsComplete = false };
            var manager = new TodoListManager(mockRepository);

            // Act
            manager.AddTodoItem(newItem);
            

            // Assert
            Assert.True(manager.GetTodoItems().First().IsComplete);
        }

       
    }
}