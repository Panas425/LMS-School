using AutoMapper;
using LMS.API.Models.Entities;

namespace LMS.API.Models.Dtos.Mapper
{
    public class MapperManager : Profile
    {
        public MapperManager()
        {
            CreateMap<Activity, ActivityDto>().ReverseMap();
            CreateMap<Activity, ActivityPutDto>().ReverseMap();
            
            CreateMap<Activity, ActivityListDto>()
                .ForMember(dest => dest.ActivityType, opt => 
                                                      opt.MapFrom (src => $"{src.ActivityType!.Name}"));


            CreateMap<ApplicationUser, UserForListDto>()
                .ForMember(dest => dest.CourseIDs, opt => opt.MapFrom(
                    src => src.CourseUsers.Select(cu => cu.CourseId).ToList()
                ))
                .ForMember(dest => dest.Role, opt => opt.Ignore()) // you'll set Role manually later
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));







            CreateMap<ActivityType, ActivityTypeDto>().ReverseMap();
            CreateMap<Module, ModuleDto>().ReverseMap();
            CreateMap<Module, ModuleManipulationDto>().ReverseMap();
            CreateMap<Module, ModuleForUpdateDto>().ReverseMap();

            CreateMap<ApplicationUser, UserForRegistrationDto>().ReverseMap();
            CreateMap<ApplicationUser, UserForUpdateDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, CourseForUpdateDto>().ReverseMap();
            CreateMap<ModuleForUpdateDto, Module>().ReverseMap();


        }
    }
}
