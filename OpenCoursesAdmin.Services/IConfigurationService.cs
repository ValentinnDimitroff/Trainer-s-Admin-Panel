namespace OpenCoursesAdmin.Services
{
    using OpenCoursesAdmin.Data.Models.QuizModels.ConfigurationModels;
    using TAS.DTO;

    public interface IConfigurationService
    {
        void AddQuizInfo(Configuration configuration);

        void CreateConfiguration(ConfigurationViewModel configViewModel);
    }
}
