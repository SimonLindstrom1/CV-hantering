﻿using System.ComponentModel.DataAnnotations;

namespace CV_hantering_REST_API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Description { get; set; }
        public virtual List<Education>? Educations { get; set; }
        public virtual List<WorkExperience>? WorkExperiences { get; set; }
    }
}
