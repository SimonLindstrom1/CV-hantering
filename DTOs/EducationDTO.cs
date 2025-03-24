using System.ComponentModel.DataAnnotations;

namespace CV_hantering_REST_API.DTOs
{
    public class EducationDTO
    {

        public int Id { get; set; }
        public required string SchoolName { get; set; }


        public string? Degree { get; set; }

        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public int? UserIdFK { get; set; }

    }
}
