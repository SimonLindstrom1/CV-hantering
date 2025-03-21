using CV_hantering_REST_API.Data;
using CV_hantering_REST_API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CV_hantering_REST_API.Services
{
    public class EducationService(CVhanteringDBContext context)
    {
        public async Task<List<EducationDTO>> GetAllEducations()
        {
            var EducationList = await context.Educations.Select(e => new EducationDTO
            {
                SchoolName = e.School,
                Degree = e.Degree
            }).ToListAsync();

            return EducationList;
        }
    }
}
