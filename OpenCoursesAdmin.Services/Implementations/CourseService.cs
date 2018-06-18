namespace OpenCoursesAdmin.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using OpenCoursesAdmin.Data.Models.CourseModels;
    using OpenCoursesAdmin.Services.Constants.RequestUrls;
    using AutoMapper.QueryableExtensions;
    using TAS.Dto.RequestDtos;

    public class CourseService : ICourseService
    {
        private readonly IExternalRequester externalRequester;

        public CourseService(IExternalRequester externalRequester)
        {
            this.externalRequester = externalRequester;
        }

        public List<CourseInstance> GetAllOpenCoursesInstancesWithUsersCount() => this.externalRequester
            .GetListOfItems<CourseInstanceDto>(RequestUrls.GetAllOpenCoursesInstances)
            .AsQueryable()
            .ProjectTo<CourseInstance>()
            .ToList();
    }
}