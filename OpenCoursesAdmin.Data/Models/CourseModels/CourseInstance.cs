namespace OpenCoursesAdmin.Data.Models.CourseModels
{
    using System.Collections.Generic;
    using OpenCoursesAdmin.Data.Models.SurveyModels;

    public class CourseInstance
    {
        public int Id { get; set; }

        public int ExternalId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public int? OnsiteStudentsCount { get; set; }

        public int? OnlineStudentsCount { get; set; }

        public int? SpectatorsCount { get; set; }

        public int? MiddleSurveyId { get; set; }

        public int? FinalSurveyId { get; set; }

        public Survey MiddleSurvey { get; set; }

        public Survey FinalSurvey { get; set; }

        public Course Course { get; set; }

        public List<CourseTopic> CourseTopics { get; set; } = new List<CourseTopic>();
    }
}
