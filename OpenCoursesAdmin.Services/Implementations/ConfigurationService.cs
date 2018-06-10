namespace OpenCoursesAdmin.Services.Implementations
{
    using System.Linq;
    using OpenCoursesAdmin.Data;
    using OpenCoursesAdmin.Data.Models.QuizModels.ConfigurationModels;
    using TAS.DTO;

    public class ConfigurationService : IConfigurationService
    {
        private readonly OCADbContext dbcontext;
        private readonly IExternalRequester externalRequester;

        public ConfigurationService(OCADbContext dbcontext, IExternalRequester externalRequester)
        {
            this.dbcontext = dbcontext;
            this.externalRequester = externalRequester;
        }

        public async void CreateConfiguration(ConfigurationViewModel configViewModel)
        {
            Configuration configuration = configViewModel.Configuration;

            this.AddQuizInfo(configuration);

            configuration.ExternalId = this.externalRequester
                .CreateRecordReturnId(configuration, configuration.Quiz.ExternalId.ToString(), new[] {"Name",
                    "AllowMultipleParticipations", "DurationInSeconds", "KeepQuestionsOrder",
                    "PossibleAnswersCount", "QuestionsCount"});

            configuration.ConfigSchedules.Add(configViewModel.ConfigSchedule);
            this.dbcontext.Add(configuration);
            await this.dbcontext.SaveChangesAsync();

            ConfigSchedule configSchedule =
                this.dbcontext.Configurations.Find(configuration.Id).ConfigSchedules.First();

            configSchedule.ExternalId = this.externalRequester
                .CreateRecordReturnId(configSchedule, configSchedule.Configuration.ExternalId.ToString(), new[] {"StartAfter",
                    "EndBefore", "Password"});

            this.dbcontext.Update(configuration);
            await this.dbcontext.SaveChangesAsync();
        }

        public void AddQuizInfo(Configuration configuration)
        {
            configuration.Quiz = this.dbcontext.Quizs.Find(configuration.QuizId);

            configuration.Name = configuration.Quiz.Name;
            configuration.QuestionsCount = this.dbcontext.QuizQuestions
                .Count(q => q.QuizId == configuration.QuizId);
            configuration.PossibleAnswersCount = this.dbcontext.QuizAnswers
                .Count(qa => qa.QuizQuestion.QuizId == configuration.QuizId
                && qa.Correct);
        }
    }
}
