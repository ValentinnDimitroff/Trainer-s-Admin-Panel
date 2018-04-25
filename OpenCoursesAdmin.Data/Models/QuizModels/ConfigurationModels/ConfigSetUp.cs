namespace OpenCoursesAdmin.Data.Models.QuizModels.ConfigurationModels
{
    public class ConfigSetUp
    {
        public int Id { get; set; }

        public int ConfigurationId { get; set; }

        public int ExternalId { get; set; }

        public string StartAfter { get; set; }

        public string EndBefore { get; set; }

        public string Password { get; set; }

        public string AllowedIps { get; set; }

        public Configuration Configuration { get; set; }
    }
}
