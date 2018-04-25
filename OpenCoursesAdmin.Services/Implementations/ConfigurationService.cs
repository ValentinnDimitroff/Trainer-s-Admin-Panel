namespace OpenCoursesAdmin.Services.Implementations
{
    using System.Linq;
    using OpenCoursesAdmin.Data;
    using OpenCoursesAdmin.Data.Models.QuizModels.ConfigurationModels;

    public class ConfigurationService : ExternalCreator, IConfigurationService
    {
        private readonly OCADbContext dbcontext;

        public ConfigurationService(OCADbContext dbcontext)
        {
            this.dbcontext = dbcontext;
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
