using System.ComponentModel.DataAnnotations.Schema;

namespace CV_hantering_REST_API.DTOs
{
    public class CreateEducationDTO
    {
        public required string School { get; set; }
        public string? Degree { get; set; }

        public string? FieldOfStudy { get; set; }
        public required DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        
        
        [ForeignKey("User")]
        public int? UserIdFK { get; set; }
    }
}
