namespace OpenCoursesAdmin.Services
{
    using OpenCoursesAdmin.Data.Models.QuizModels;

    public interface IQuizsService : IExternalRequester
    {
        bool PublishQuestions(Quiz quiz);
    }
}
