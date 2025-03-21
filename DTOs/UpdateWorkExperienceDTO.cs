using System.ComponentModel.DataAnnotations.Schema;

namespace CV_hantering_REST_API.DTOs
{
    public class UpdateWorkExperienceDTO
    {
        public string? JobTitle { get; set; }
        public string? Employer { get; set; }
        public string? Description { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}
