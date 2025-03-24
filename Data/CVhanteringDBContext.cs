using Microsoft.EntityFrameworkCore;
using CV_hantering_REST_API.Models;

namespace CV_hantering_REST_API.Data
{
    public class CVhanteringDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Education> Educations { get; set; }

        public DbSet<WorkExperience> WorkExperiences { get; set; }
    }
}
