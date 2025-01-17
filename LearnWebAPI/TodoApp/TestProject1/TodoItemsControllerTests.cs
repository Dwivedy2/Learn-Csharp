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
            Guid Id1 = Guid.Parse("3699d388-561b-4f50-992b-a7506289e709");
            Guid Id2 = Guid.Parse("3699d388-561b-4f50-992b-a7506289e708");
            Guid IdToTest = Id2;
            DateTime CurrentTime = DateTime.Now;
            TodoItem todoItemToTest = new TodoItem { Id = Id2, DateCreated = CurrentTime, IsCompleted = false, Title = "Task 2" };

            var getTodoItem = new GetTodoItemDto 
            { Id = IdToTest, DateCreated = CurrentTime, IsCompleted = false, Title= "Task 2" };

            _mockRepo.Setup(repo => repo.TodoItems.GetItemByIdAsync(IdToTest))
                .ReturnsAsync(todoItemToTest);

            _mockMapper.Setup(mapper => mapper.Map<GetTodoItemDto>(It.IsAny<TodoItem>()))
                .Returns((TodoItem source) => new GetTodoItemDto 
                { Id = source.Id, Title = source.Title, DateCreated = source.DateCreated, IsCompleted = source.IsCompleted });

            // Act 
            var result = await _controller.GetByIdAsync(IdToTest);

            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);

            var serviceResponse = Assert.IsType<ServiceResponse<GetTodoItemDto>>(okObjectResult.Value);

            // Assert
            Assert.True(serviceResponse.IsSuccessful);
            Assert.Equal(getTodoItem.Id, serviceResponse.Data.Id);
            Assert.Equal(getTodoItem.Title, serviceResponse.Data.Title);
            Assert.Equal(getTodoItem.DateCreated, serviceResponse.Data.DateCreated);
            Assert.Equal(getTodoItem.IsCompleted, serviceResponse.Data.IsCompleted);
        }

        [Fact]
        public async Task GetById_ShouldReturnBadRequest_ForIncorrectFormatId()
        {
            // Arrange
            Guid ItemIdToTest = Guid.Empty;
            TodoItem emptyTodo = new TodoItem();

            _mockRepo.Setup(repo => repo.TodoItems.GetItemByIdAsync(ItemIdToTest))
                .ReturnsAsync(emptyTodo);

            // Act
            var result = await _controller.GetByIdAsync(ItemIdToTest);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetById_ShouldReturnNotFound_ForIdNotExits()
        {
            // Arrange
            Guid IdToTest = new Guid("0fecc3e0-183f-4f3f-affc-0587ab81f187");
            var emptyTodoItem = new TodoItem();

            _mockRepo.Setup(repo => repo.TodoItems.GetByIdAsync(IdToTest))
                .ReturnsAsync(emptyTodoItem);

            // Act
            var result = await _controller.GetByIdAsync(IdToTest);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public async Task AddTodoItemAsync_ShouldReturnOkObjectResult_ForSingleTodoItem()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            DateTime dateTime = DateTime.Now;
            TodoItemDto itemDtoToAdd = new TodoItemDto { IsCompleted = false, Title = "New Item" };
            TodoItem itemToAdd = new TodoItem
            { 
                Id = id, 
                Title = itemDtoToAdd.Title, 
                DateCreated = dateTime, 
                IsCompleted = itemDtoToAdd.IsCompleted 
            };
            TodoItem addedItem = itemToAdd;
            GetTodoItemDto returnTodoItem = new GetTodoItemDto
            {
                Id = id,
                Title = itemDtoToAdd.Title,
                DateCreated = dateTime,
                IsCompleted = itemDtoToAdd.IsCompleted
            };

            _mockMapper.Setup(mapper => mapper.Map<TodoItem>(It.IsAny<TodoItemDto>()))
                .Returns((TodoItemDto source) => new TodoItem
                { Id = id, Title = source.Title, DateCreated = dateTime, IsCompleted = source.IsCompleted });

            _mockRepo.Setup(repo => repo.TodoItems.AddItemAsync(itemToAdd))
                .ReturnsAsync(addedItem);

            _mockMapper.Setup(mapper => mapper.Map<GetTodoItemDto>(It.IsAny<TodoItem>()))
                .Returns((TodoItem source) => new GetTodoItemDto 
                { Id = id, Title = itemDtoToAdd.Title, DateCreated = dateTime, IsCompleted = itemDtoToAdd.IsCompleted });

            // Act
            var result = await _controller.AddTodoItemAsync(itemDtoToAdd);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            var serviceResponse = Assert.IsType<ServiceResponse<GetTodoItemDto>>(okResult.Value);

            // Assert
            Assert.True(serviceResponse.IsSuccessful);
            Assert.Equal(returnTodoItem.Id, serviceResponse.Data.Id);
            Assert.Equal(returnTodoItem.Title, serviceResponse.Data.Title);
            Assert.Equal(returnTodoItem.DateCreated, serviceResponse.Data.DateCreated);
            Assert.Equal(returnTodoItem.IsCompleted, serviceResponse.Data.IsCompleted);
        }
    }
}
