namespace OpenCoursesAdmin.Data.Models.SurveyModels
{
    public class SurveyAnswer
    {
        public int Id { get; set; }

        public int SurveyId { get; set; }

        public int QuestionId { get; set; }

        public int? StudentId { get; set; }

        public bool? Starred { get; set; }

        public string Text { get; set; }

        public int Score { get; set; }

        public override bool Equals(object obj) => (obj as SurveyAnswer).Id == this.Id;

        public override int GetHashCode() => this.Id * 3 / 15;
    }
}
