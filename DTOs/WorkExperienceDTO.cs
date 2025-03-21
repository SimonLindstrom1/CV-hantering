using System.ComponentModel.DataAnnotations;

namespace CV_hantering_REST_API.DTOs
{
    public class WorkExperienceDTO
    {
        [Required]
        public required string JobTitle { get; set; }

        [Required]
        public required string Employer { get; set; }

        [Required]
        public required DateOnly? StartDate { get; set; }

        [Required]
        public DateOnly? EndDate { get; set; }
    }
}
