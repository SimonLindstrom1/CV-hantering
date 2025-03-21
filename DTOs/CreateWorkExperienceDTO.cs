using System.ComponentModel.DataAnnotations.Schema;

namespace CV_hantering_REST_API.DTOs
{
    public class CreateWorkExperienceDTO
    {
        [ForeignKey("User")]
        public required int UserIdFk { get; set; }
        public required string JobTitle { get; set; }
        public required string Employer { get; set; }
        public string? Description { get; set; }
        public required DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}
