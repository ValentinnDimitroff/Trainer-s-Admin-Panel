namespace OpenCoursesAdmin.Services.Implementations
{
    using System.Collections.Generic;
    using OpenCoursesAdmin.Data.Models.CourseModels;
    using OpenCoursesAdmin.Services.Constants.RequestUrls;
    using OpenCoursesAdmin.Services.Models.RequestModels;

    public class CourseService : ICourseService
    {
        private readonly IExternalRequester externalRequester;

        public CourseService(IExternalRequester externalRequester)
        {
            this.externalRequester = externalRequester;
        }
    
        public List<CourseInstance> GetAllOpenCoursesInstances()
        {
            List<UsersInOpenCourse> usersInOpenCourses =  this.externalRequester.GetListOfItems<UsersInOpenCourse>(RequestUrls.GetAllOpenCoursesInstances);
            //TODO AutoMapper

            return new List<CourseInstance>();
            //TODO - Visualize All Courses in Grid
        }
    }
}