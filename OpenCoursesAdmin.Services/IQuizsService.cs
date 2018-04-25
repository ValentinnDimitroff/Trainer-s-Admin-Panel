namespace OpenCoursesAdmin.Services
{
    using OpenCoursesAdmin.Data.Models.QuizModels;

    public interface IQuizsService : IExternalCreator
    {
        bool PublishQuestions(Quiz quiz);
    }
}
