namespace OpenCoursesAdmin.Data.Models.QuizModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class QuizQuestion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int QuizId { get; set; }

        public int ExternalId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Text { get; set; }

        [MaxLength(1)]
        public string Type { get; set; }

        public Quiz Quiz { get; set; }

        public List<QuizAnswer> Answers { get; set; } = new List<QuizAnswer>();
    }
}
