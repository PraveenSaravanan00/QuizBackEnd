using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuizzApplication.Model
{
    public class particularQuestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ? id { get; set; }
        [Required]
        public string questions { get; set; }
        [Required]
        public string optionA { get; set; }
        [Required]
        public string optionB { get; set; }
        [Required]
        public string optionC { get; set; }
        [Required]
        public string optionD { get; set; }
        [Required]
        public string Answers { get; set; }
    }
}
