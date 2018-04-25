namespace OpenCoursesAdmin.Services
{
    using OpenCoursesAdmin.Data.Models.QuizModels.ConfigurationModels;

    public interface IConfigurationService : IExternalCreator
    {
        void AddQuizInfo(Configuration configuration);
    }
}
