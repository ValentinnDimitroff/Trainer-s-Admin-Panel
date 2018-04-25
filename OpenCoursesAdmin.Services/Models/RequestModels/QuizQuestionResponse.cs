namespace OpenCoursesAdmin.Services.Models.RequestModels
{
    public class QuizQuestionResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int QuestionsCount { get; set; }
    }
}