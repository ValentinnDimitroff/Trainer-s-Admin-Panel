namespace TAS.Dto.RequestDtos
{
    public class SurveyAnswerDto{

        public int Id { get; set; }

        public string UserName { get; set; }

        public string ParticipationKey { get; set; }

        public int SurveyId { get; set; }

        public int SurveyInstanceId { get; set; }

        public string Section { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public bool IsCorrectAnswer { get; set; }

        public string CreatedOn { get; set; }

        public string ModifiedOn { get; set; }
    }
}
