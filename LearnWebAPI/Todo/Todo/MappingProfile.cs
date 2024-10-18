using AutoMapper;
using Todo.DTOs;
using Todo.Entities;

namespace Todo
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddDto, ToDos>();
            CreateMap<UpdateDto, ToDos>();
        }
    }
}
