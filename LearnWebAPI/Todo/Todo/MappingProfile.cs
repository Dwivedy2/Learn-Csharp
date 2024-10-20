using AutoMapper;
using Todo.DTOs.Todos;
using Todo.DTOs.Users;
using Todo.Entities;

namespace Todo
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddDto, ToDos>();
            CreateMap<UpdateDto, ToDos>();
            CreateMap<GetUserDetailDto, User>().ReverseMap();
            CreateMap<GetTodoDto, ToDos>().ReverseMap();
        }
    }
}
