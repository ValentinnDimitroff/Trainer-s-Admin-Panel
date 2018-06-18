namespace OpenCoursesAdmin.Data.Models.SurveyModels
{
    using System;
    using System.Collections.Generic;
    using OpenCoursesAdmin.Data.Enums;

    public class Survey
    {
        public int Id { get; set; }

        public int? ExternalId { get; set; }

        public SurveyType SurveyType { get; set; }

        public double? CourseAverageScore { get; set; }

        public double? TrainerAverageScore { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool? HasEnded { get; set; }

        public List<SurveyAnswer> SurveyAnswers { get; set; } = new List<SurveyAnswer>();
    }
}
