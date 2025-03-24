using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CV_hantering_REST_API.Models
{
    public class Education
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int? UserIdFK { get; set; }

        [Required]
        public string School { get; set; }

        public string? Degree { get; set; }

        public string? FieldOfStudy { get; set; }

        [Required]
        public DateOnly StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public virtual User? User { get; set; }
    }
}