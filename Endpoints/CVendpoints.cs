using CV_hantering_REST_API.Services;
using CV_hantering_REST_API.DTOs;
using CV_hantering_REST_API.Data;
using CV_hantering_REST_API.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CV_hantering_REST_API.Endpoints
{
    public class CVendpoints
    {
        public static void RegisterEndpoints(WebApplication app)
        {
            app.MapGet("GetAllEducations", async ([FromServices] EducationService educationService) =>
            {
                return await educationService.GetAllEducations();
            });

            app.MapGet("GetAllExperiences", async ([FromServices] WorkExperienceService experienceService) =>
            {
                return await experienceService.GetAllWorkExperiences();
            });

            app.MapGet("GetAllUsers", async ([FromServices] UserService userService) =>
            {
                return await userService.GetAllUsers();
            });

            app.MapGet("/user/{id}", async ([FromServices] UserService userService, int id) =>
            {
                return await userService.GetUserById(id);
            });

            app.MapPost("/Education", async ([FromBody] CreateEducationDTO newEducation, [FromServices] CVhanteringDBContext context) =>
            {
                var validationContext = new ValidationContext(newEducation);
                var validationResult = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(newEducation, validationContext, validationResult);

                if (!isValid)
                {
                    return Results.BadRequest(validationResult.Select(validationResult => validationResult.ErrorMessage));
                }

                var education = new Education
                {
                    School = newEducation.School,
                    Degree = newEducation.Degree,
                    StartDate = newEducation.StartDate,
                    EndDate = newEducation.EndDate,
                    UserIdFK = newEducation.UserIdFK,
                };

                context.Educations.Add(education);
                await context.SaveChangesAsync();

                return Results.Ok(education);
            });

            app.MapPost("/WorkExperience", async ([FromBody] CreateWorkExperienceDTO newWorkExperience, [FromServices] WorkExperienceService workExperienceService) =>
            {
                var validationContext = new ValidationContext(newWorkExperience);
                var validationResult = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(newWorkExperience, validationContext, validationResult, true);

                if (!isValid)
                {
                    return Results.BadRequest(validationResult.Select(vr => vr.ErrorMessage));
                }

                var response = await workExperienceService.AddWorkExperience(newWorkExperience);

                return Results.Ok(response);
            });

            app.MapPut("/Education", async ([FromBody] UpdateEducationDTO updatedEducation, [FromServices] EducationService educationService) =>
            {
                var validationContext = new ValidationContext(updatedEducation);
                var validationResult = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(updatedEducation, validationContext, validationResult, true);

                if (!isValid)
                {
                    return Results.BadRequest(validationResult.Select(vr => vr.ErrorMessage));
                }

                var response = await educationService.UpdateEducation(updatedEducation);

                if (response == null)
                {
                    return Results.NotFound("Education not found.");
                }

                return Results.Ok(response);
            });

            app.MapDelete("/WorkExperience/{id}", async ([FromServices] WorkExperienceService workExperienceService, int id) =>
            {
                var result = await workExperienceService.DeleteWorkExperience(id);
                if (!result)
                {
                    return Results.NotFound("Work experience not found.");
                }

                return Results.NoContent();
            });

            app.MapGet("/github/{username}", async ([FromServices] GitHubServices gitHubService, string username) =>
            {
                var repositories = await gitHubService.GetRepositoriesByUsername(username);
                return Results.Ok(repositories);
            });
        }
    }
}
