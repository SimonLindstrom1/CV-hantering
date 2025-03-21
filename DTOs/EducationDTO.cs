using System.ComponentModel.DataAnnotations;

namespace CV_hantering_REST_API.DTOs
{
    public class EducationDTO
    {

        [Required]
        public required string SchoolName { get; set; }

        [Required]
        public string? Degree { get; set; }

    }
}
