namespace OpenCoursesAdmin.Data.Models.QuizModels
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using OpenCoursesAdmin.Data.Enums;

    public class QuizQuestion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int QuizId { get; set; }

        public int ExternalId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        [MaxLength(1)]
        public SurveyQuestionType Type { get; set; }

        public int CorrectAnswerPoints { get; set; }

        public Quiz Quiz { get; set; }

        public List<QuizAnswer> Answers { get; set; } = new List<QuizAnswer>();
    }
}
