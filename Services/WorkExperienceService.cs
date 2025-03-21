using CV_hantering_REST_API.Data;
using CV_hantering_REST_API.DTOs;

namespace CV_hantering_REST_API.Services
{
    public class WorkExperienceService(CVhanteringDBContext context)
    {
        public async Task<List<WorkExperienceDTO>> GetAllWorkExperiences()
        {
            var WorkExperienceList = await context.WorkExperiences.Select(w => new WorkExperienceDTO
            {
                JobTitle = w.JobTitle,
                Employer = w.Employer,
                StartDate = w.StartDate,
                EndDate = w.EndDate
            }).ToListAsync();
            return WorkExperienceList;
        }
    }
}
