using AutoMapper;
using TaskManager.Application.DTOs;
using TaskManager.Core.Entities;

namespace TaskManager.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping from ToDoTask to ToDoTaskDto
            CreateMap<ToDoTask, ToDoTaskDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.IsCompleted))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.CompletedAt, opt => opt.MapFrom(src => src.CompletedAt))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .AfterMap((src, dest) =>
                {
                    if (src.IsCompleted && !dest.IsCompleted)
                        dest.MarkComplete();
                    else if (!src.IsCompleted && dest.IsCompleted)
                        dest.MarkIncomplete();
                });

            // Mapping from CreateToDoTaskDto to ToDoTask
            CreateMap<CreateToDoTaskDto, ToDoTask>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.IsCompleted))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow)) // Set current date/time
                .ForMember(dest => dest.CompletedAt, opt => opt.MapFrom(src => src.CompletedAt));
        }
    }
}