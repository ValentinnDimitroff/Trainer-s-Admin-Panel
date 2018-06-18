namespace OpenCoursesAdmin.Services
{
    using System.Collections.Generic;
    using OpenCoursesAdmin.Data.Models.QuizModels;

    public interface IQuizsService
    {
        List<Quiz> GetAllQuizzes();

        void CreateQuiz(Quiz quiz);

        bool PublishQuestions(Quiz quiz);
    }
}
