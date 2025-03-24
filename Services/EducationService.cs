using CV_hantering_REST_API.Data;
using CV_hantering_REST_API.DTOs;
using CV_hantering_REST_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CV_hantering_REST_API.Services
{
    public class EducationService
    {
        private readonly CVhanteringDBContext context;

        public EducationService(CVhanteringDBContext context)
        {
            this.context = context;
        }

        public async Task<List<EducationDTO>> GetAllEducations()
        {
            var educationList = await context.Educations.Select(e => new EducationDTO
            {
                Id = e.Id,
                SchoolName = e.School,
                Degree = e.Degree,
                StartDate = e.StartDate,
                EndDate = e.EndDate
            }).ToListAsync();

            return educationList;
        }

        public async Task<EducationDTO> GetEducationById(int id)
        {
            var education = await context.Educations.FirstOrDefaultAsync(e => e.Id == id);
            if (education == null)
            {
                return null;
            }
            return new EducationDTO
            {
                Id = education.Id,
                SchoolName = education.School,
                Degree = education.Degree,
                StartDate = education.StartDate,
                EndDate = education.EndDate
            };
        }

        public async Task<EducationDTO> AddEducation(CreateEducationDTO newEducation)
        {
            var education = new Education
            {
                School = newEducation.School,
                Degree = newEducation.Degree,
                StartDate = newEducation.StartDate,
                EndDate = newEducation.EndDate,
                UserIdFK = newEducation.UserIdFK
            };

            context.Educations.Add(education);
            await context.SaveChangesAsync();

            return new EducationDTO
            {
                Id = education.Id,
                SchoolName = education.School,
                Degree = education.Degree,
                StartDate = education.StartDate,
                EndDate = education.EndDate
            };
        }
        public async Task<EducationDTO?> UpdateEducation(UpdateEducationDTO updatedEducation)
        {
            var education = await context.Educations.FindAsync(updatedEducation.Id);
            if (education == null)
            {
                return null;
            }

            education.School = updatedEducation.School;
            education.Degree = updatedEducation.Degree;
            education.StartDate = updatedEducation.StartDate;
            education.EndDate = updatedEducation.EndDate;
            education.UserIdFK = updatedEducation.UserIdFK;

            await context.SaveChangesAsync();

            return new EducationDTO
            {
                Id = education.Id,
                SchoolName = education.School,
                Degree = education.Degree,
                StartDate = education.StartDate,
                EndDate = education.EndDate
            };
        }
    }
}
