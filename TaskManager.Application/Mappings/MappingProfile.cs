using AutoMapper;
using TaskManager.Application.DTOs;
using TaskManager.Core.Entities;

namespace TaskManager.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<ToDoTask, ToDoTaskDto>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}