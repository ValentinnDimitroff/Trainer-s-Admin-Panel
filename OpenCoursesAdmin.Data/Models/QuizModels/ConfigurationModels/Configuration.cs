namespace OpenCoursesAdmin.Data.Models.QuizModels.ConfigurationModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Configuration
    {
        private int durationInMinutes;

        public Configuration()
        {
        }

        public Configuration(string name)
        {
            this.Name = name;
        }

        public int Id { get; set; }

        public int QuizId { get; set; }

        public int ExternalId { get; set; }

        [NotMapped]
        [Range(5, int.MaxValue)]
        public int DurationInMinutes
        {
            get => this.durationInMinutes;
            set
            {
                this.durationInMinutes = value;
                this.DurationInSeconds = value * 60;
            }
        }

        [Range(300, int.MaxValue)]
        public int DurationInSeconds { get; set; }

        public string Name { get; set; }

        public int PollQuestionsCount { get; set; }

        public int PossibleAnswersCount { get; set; }

        public int QuestionsCount { get; set; }

        public bool KeepQuestionsOrder { get; set; }

        public bool AllowMultipleParticipations { get; set; }

        public int TestId { get; set; }

        public Quiz Quiz { get; set; }

        public List<ConfigSchedule> ConfigSchedules { get; set; }
    }
}
