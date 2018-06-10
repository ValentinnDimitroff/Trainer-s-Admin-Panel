namespace OpenCoursesAdmin.Data.Models.CourseModels
{
    using System.Collections.Generic;

    public class Module
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
