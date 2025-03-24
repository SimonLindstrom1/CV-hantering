using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CV_hantering_REST_API.Models
{
    public class WorkExperience
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public required int UserIdFK { get; set; }
        public required string JobTitle { get; set; }
        public required string Employer { get; set; }
        public string? Description { get; set; }
        public required DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }

    }
}
