namespace OpenCoursesAdmin.Profiles
{
    using AutoMapper;
    using OpenCoursesAdmin.Data.Models.CourseModels;
    using TAS.Dto.RequestDtos;

    public class SoftUniProfile : Profile
    {
        public SoftUniProfile()
        {
            this.CreateMap<CourseInstanceDto, CourseInstance>()
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NameBg))
                .ForMember(dest => dest.OnlineStudentsCount, opt => opt.MapFrom(src => src.OnlineUsersCount))
                .ForMember(dest => dest.OnsiteStudentsCount, opt => opt.MapFrom(src => src.OnsiteUsersCount));
        }
    }
}
