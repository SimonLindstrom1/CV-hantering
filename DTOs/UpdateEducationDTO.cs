using System.ComponentModel.DataAnnotations.Schema;

namespace CV_hantering_REST_API.DTOs
{
    public class UpdateEducationDTO
    {
        public int Id { get; set; }
        public string? School { get; set; }
        public string? Degree { get; set; }
        [ForeignKey("User")]
        public int? UserIdFK { get; set; }
        public string? FieldOfStudy { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}
