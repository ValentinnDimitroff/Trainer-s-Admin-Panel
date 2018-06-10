namespace OpenCoursesAdmin.Data.Models.SurveyModels
{
    using System.Collections.Generic;
    using OpenCoursesAdmin.Data.Enums;

    public class SurveyQuestion
    {
        public int Id { get; set; }

        public QuestionType QuestionType { get; set; }

        public string Text { get; set; }

        public List<SurveyAnswer> SurveyAnswers { get; set; } = new List<SurveyAnswer>();

        public override bool Equals(object obj) => (obj as SurveyQuestion).Text == this.Text;

        public override int GetHashCode() => this.Text.GetHashCode();
    }
}
