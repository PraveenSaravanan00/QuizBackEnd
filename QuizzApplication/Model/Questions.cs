using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizzApplication.Model
{
    public class Questions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id {  get; set; }
        [Required]
        public string questions {  get; set; }
        public string? optionA { get; set; }
        public string? optionB { get; set; }
        public string? optionC { get; set; }
        public string? optionD { get; set; }
        [Required]
        public string Answers { get; set; }
        [Required]
        public string Languages { get; set; }
        [Required]
        public string Levels { get; set; }


    }
}
