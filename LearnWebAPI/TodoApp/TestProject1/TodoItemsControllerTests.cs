using AutoMapper;
using Common;
using Contract;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TodoApp.Controllers;

namespace WebApiTests
{
    public class TodoItemsControllerTests
    {
        private readonly Mock<IRepositoryWrapper> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly TodoItemsController _controller;
        public TodoItemsControllerTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockRepo = new Mock<IRepositoryWrapper>();
            _controller = new TodoItemsController(_mockRepo.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOkResult_WithListOfItems()
        {
            // Arrange
            var todoItems = new List<TodoItem> 
            {
                new TodoItem { Id = Guid.NewGuid(), DateCreated = DateTime.Now, IsCompleted = false, Title = "Task 1" },
                new TodoItem { Id = Guid.NewGuid(), DateCreated = DateTime.Now, IsCompleted = true, Title = "Task 2" },
            };

            var getTodoItemDtos = new List<GetTodoItemDto>
            {
                new GetTodoItemDto { Id = Guid.NewGuid(), DateCreated = DateTime.Now, IsCompleted = false, Title = "Task 1" },
                new GetTodoItemDto { Id = Guid.NewGuid(), DateCreated = DateTime.Now, IsCompleted = true, Title = "Task 2" },
            };

            _mockRepo.Setup(repo => repo.TodoItems.GetAllItemsAsync())
                .ReturnsAsync(todoItems);

            _mockMapper.Setup(mapper => mapper.Map<GetTodoItemDto>(It.IsAny<TodoItem>()))
                .Returns((TodoItem source) => new GetTodoItemDto 
                { Id = source.Id, DateCreated = DateTime.Now, Title = source.Title, IsCompleted = source.IsCompleted });

            // Act
            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            var serviceResponse = Assert.IsType<ServiceResponse<IEnumerable<GetTodoItemDto>>>(okResult.Value);

            // Assert
            Assert.True(serviceResponse.IsSuccessful);
            Assert.Equal(2, serviceResponse.Data.Count());
        }

        [Fact]
        public async Task GetAll_ShouldReturnNoContent_WithoutListItems()
        {
            // Arrange
            var emptyTodoItems = new List<TodoItem>();

            _mockRepo.Setup(repo => repo.TodoItems.GetAllItemsAsync())
                .ReturnsAsync(emptyTodoItems);

            // Act
            var result = await _controller.GetAll();

            // Assert
            Assert.IsType<NoContentResult>(result.Result);
        }

        [Fact]
        public async Task GetById_ShouldReturnOkObjectResult_WithItem()
        {
            // Arrange
            Guid IdToTest = Guid.Parse("3699d388-561b-4f50-992b-a7506289e709");
            DateTime CurrentTime = DateTime.Now;

            var todoItem = new TodoItem { Id = IdToTest, DateCreated = CurrentTime, IsCompleted = false, Title = "Task 1" };

            var getTodoItem = new GetTodoItemDto 
            { Id = IdToTest, DateCreated = CurrentTime, IsCompleted = false, Title= "Task 1" };

            _mockRepo.Setup(repo => repo.TodoItems.GetItemByIdAsync(IdToTest))
                .ReturnsAsync(todoItem);

            _mockMapper.Setup(mapper => mapper.Map<GetTodoItemDto>(It.IsAny<TodoItem>()))
                .Returns((TodoItem source) => new GetTodoItemDto 
                { Id = source.Id, Title = source.Title, DateCreated = source.DateCreated, IsCompleted = source.IsCompleted });

            // Act 
            var result = await _controller.GetById(IdToTest);

            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);

            var serviceResponse = Assert.IsType<ServiceResponse<GetTodoItemDto>>(okObjectResult.Value);

            // Assert
            Assert.True(serviceResponse.IsSuccessful);
            Assert.Equal(getTodoItem.Id, serviceResponse.Data.Id);
            Assert.Equal(getTodoItem.Title, serviceResponse.Data.Title);
            Assert.Equal(getTodoItem.DateCreated, serviceResponse.Data.DateCreated);
            Assert.Equal(getTodoItem.IsCompleted, serviceResponse.Data.IsCompleted);
        }

    }
}
