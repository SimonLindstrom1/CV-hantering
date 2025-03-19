using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CV_hantering_REST_API.Models
{
    public class Education
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("User")]
        public int UserIdFK { get; set; }


        public required string School { get; set; }
        public string? Degree { get; set; }
        
        public string? FieldOfStudy { get; set; }
        public required DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}
