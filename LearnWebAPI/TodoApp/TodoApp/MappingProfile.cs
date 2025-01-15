using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace TodoApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<TodoItem, TodoItemDto>().ReverseMap();
            CreateMap<TodoItem, TodoItemDto>().ReverseMap();
        }
    }
}
