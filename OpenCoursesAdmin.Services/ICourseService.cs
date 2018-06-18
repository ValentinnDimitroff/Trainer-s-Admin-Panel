namespace OpenCoursesAdmin.Services
{
    using System.Collections.Generic;
    using OpenCoursesAdmin.Data.Models.CourseModels;

    public interface ICourseService
    {
        List<CourseInstance> GetAllOpenCoursesInstancesWithUsersCount();
    }
}
