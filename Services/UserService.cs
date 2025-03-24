using CV_hantering_REST_API.Data;
using CV_hantering_REST_API.DTOs;
using Microsoft.EntityFrameworkCore;
using CV_hantering_REST_API.Models;

namespace CV_hantering_REST_API.Services
{
    public class UserService(CVhanteringDBContext context)
    {
        public async Task<List<UserDTO>> GetAllUsers()
        {
            var UserList = await context.Users.Select(u => new UserDTO
            {
                id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName
            }).ToListAsync();

            return UserList;
        }
        public async Task<UserDTO> GetUserById(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return null;
            }
            return new UserDTO
            {
                id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }         
    }
}
