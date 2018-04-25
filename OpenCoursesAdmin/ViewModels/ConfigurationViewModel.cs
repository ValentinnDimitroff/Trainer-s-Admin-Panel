namespace OpenCoursesAdmin.ViewModels
{
    using OpenCoursesAdmin.Data.Models.QuizModels.ConfigurationModels;

    public class ConfigurationViewModel
    {
        //TODO - AutoMapper
        public Configuration Configuration { get; set; }

        public ConfigSchedule ConfigSchedule { get; set; }
    }
}
