using CV_hantering_REST_API.Data;
using CV_hantering_REST_API.DTOs;
using Microsoft.EntityFrameworkCore;
using CV_hantering_REST_API.Models;

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
        public async Task<WorkExperienceDTO> GetWorkExperienceById(int id)
        {
            var workExperience = await context.WorkExperiences.FirstOrDefaultAsync(w => w.Id == id);
            if (workExperience == null)
            {
                return null;
            }
            return new WorkExperienceDTO
            {
                JobTitle = workExperience.JobTitle,
                Employer = workExperience.Employer,
                StartDate = workExperience.StartDate,
                EndDate = workExperience.EndDate
            };
        }
        public async Task<WorkExperienceDTO> AddWorkExperience(CreateWorkExperienceDTO newWorkExperience)
        {
            var workExperience = new WorkExperience
            {
                JobTitle = newWorkExperience.JobTitle,
                Employer = newWorkExperience.Employer,
                StartDate = newWorkExperience.StartDate,
                EndDate = newWorkExperience.EndDate,
                UserIdFK = newWorkExperience.UserIdFK
            };
            context.WorkExperiences.Add(workExperience);
            await context.SaveChangesAsync();
            return new WorkExperienceDTO
            {
                JobTitle = workExperience.JobTitle,
                Employer = workExperience.Employer,
                StartDate = workExperience.StartDate,
                EndDate = workExperience.EndDate
            };
        }
    }
}
