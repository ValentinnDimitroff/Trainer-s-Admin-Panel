namespace OpenCoursesAdmin.Data.Models.QuizModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class QuizAnswer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int QuizQuiestionId { get; set; }

        public int ExternalId { get; set; }

        [Required]
        public bool Correct { get; set; }

        [Required]
        [MaxLength(500)]
        public string Text { get; set; }

        public QuizQuestion QuizQuestion { get; set; }
    }
}
