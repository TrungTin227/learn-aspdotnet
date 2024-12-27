using Moq;
using Entities;
using UseCases;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace TestProject
{
    public class TodoListManagerTests
    {
        private readonly Mock<ITodoItemRepository> mockRepository;
        private readonly TodoListManager todoListManager;

        public TodoListManagerTests()
        {
            mockRepository = new Mock<ITodoItemRepository>();
            todoListManager = new TodoListManager(mockRepository.Object);
        }

        [Fact]
        public void GetTodoItems_ShouldReturnAllItems()
        {
            // Arrange
            var items = new List<TodoItem>
            {
                new TodoItem { Id = 1, Name = "Test Item 1", IsComplete = false },
                new TodoItem { Id = 2, Name = "Test Item 2", IsComplete = true }
            };
            mockRepository.Setup(repo => repo.GetItems()).Returns(items);

            // Act
            var result = todoListManager.getTodoItems();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal(items, result);
        }

        [Fact]
        public void AddTodoItem_ShouldAddItem()
        {
            // Arrange
            var newItem = new TodoItem { Id = 3, Name = "New Item", IsComplete = false };

            // Act
            todoListManager.AddTodoItem(newItem);

            // Assert
            mockRepository.Verify(repo => repo.Add(newItem), Times.Once);
        }

        [Fact]
        public void MarkComplete_ShouldMarkItemAsComplete()
        {
            // Arrange
            var item = new TodoItem { Id = 1, Name = "Test Item", IsComplete = false };
            mockRepository.Setup(repo => repo.GetById(1)).Returns(item);

            // Act
            todoListManager.MarkComplete(1);

            // Assert
            Assert.True(item.IsComplete);
            mockRepository.Verify(repo => repo.Update(item), Times.Once);
        }

        [Fact]
        public void MarkComplete_ShouldNotUpdateIfItemNotFound()
        {
            // Arrange
            mockRepository.Setup(repo => repo.GetById(1)).Returns((TodoItem)null);

            // Act
            todoListManager.MarkComplete(1);

            // Assert
            mockRepository.Verify(repo => repo.Update(It.IsAny<TodoItem>()), Times.Never);
        }

        [Fact]
        public void Delete_ShouldRemoveItem()
        {
            // Act
            todoListManager.Delete(1);

            // Assert
            mockRepository.Verify(repo => repo.Delete(1), Times.Once);
        }
    }
}
