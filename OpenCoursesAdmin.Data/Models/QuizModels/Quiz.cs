namespace OpenCoursesAdmin.Data.Models.QuizModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using OpenCoursesAdmin.Data.Models.QuizModels.ConfigurationModels;

    public class Quiz
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ExternalId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public List<QuizQuestion> Questions { get; set; } = new List<QuizQuestion>();

        public List<Configuration> Configurations { get; set; } = new List<Configuration>();
    }
}
