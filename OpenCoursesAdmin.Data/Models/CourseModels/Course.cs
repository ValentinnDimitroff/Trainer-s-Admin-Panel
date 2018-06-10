namespace OpenCoursesAdmin.Data.Models.CourseModels
{
    using System.Collections.Generic;

    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Module Module { get; set; }

        //public List<CourseTopic> CourseTopics { get; set; } = new List<CourseTopic>();

        public List<CourseInstance> CourseInstances { get; set; } = new List<CourseInstance>();
    }
}
